using Common.Enums;
using Common.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using ViewModels.Shared.Searching;

namespace Common.Helpers.Linq
{
    public static class Linq
    {
        public static PaginatedList<T> DynamicSearch<T>(this IQueryable<T> source, SearchModelVM searchModel)
        {
            List<PropertyInfo> tProperties = typeof(T).GetProperties().ToList();
            if (searchModel?.SearchFields != null)
            {
                foreach (SearchField field in searchModel.SearchFields)
                {
                    if (!tProperties.Exists(p => p.Name == field.FieldName)) continue;

                    if (!string.IsNullOrWhiteSpace(field.Value) && Enum.GetNames(typeof(Operators)).Contains(field.Operator))
                    {
                        Type actualType = tProperties.Where(p => p.Name == field.FieldName).First().PropertyType;
                        Type underlyingType = Nullable.GetUnderlyingType(actualType) ?? actualType;

                        switch (field.Operator)
                        {
                            case "Contain":
                                try
                                {
                                    // Nullable fields
                                    if (Nullable.GetUnderlyingType(actualType) != null)
                                        source = source.Where($"{field.FieldName}.Value.ToString().Trim().Contains(@0)", field.Value.Trim());
                                    else
                                        source = source.Where($"{field.FieldName}.ToString().Trim().Contains(@0)", field.Value.Trim());
                                }
                                catch (Exception) { continue; }
                                break;
                            case "NotContain":
                                try
                                {
                                    // Nullable fields
                                    if (Nullable.GetUnderlyingType(actualType) != null)
                                        source = source.Where($"!{field.FieldName}.Value.ToString().Trim().Contains(@0)", field.Value.Trim());
                                    else
                                        source = source.Where($"!{field.FieldName}.ToString().Trim().Contains(@0)", field.Value.Trim());
                                }
                                catch (Exception) { continue; }
                                break;
                            default:
                                try
                                {
                                    object safeValue;
                                    // case on timespan
                                    if (actualType == typeof(TimeSpan) || actualType == typeof(TimeSpan?))
                                        safeValue = TimeSpan.Parse(field.Value);
                                    else
                                        safeValue = (field.Value == null) ? null : Convert.ChangeType(field.Value, underlyingType);

                                    source = source.Where($"{field.FieldName} {field.Operator.ToOperator().AsString()} @0", safeValue);
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                                break;
                        }

                    }
                }
            }
            
            searchModel.OrderType = Enum.GetNames(typeof(OrderTypes)).Contains(searchModel.OrderType) 
                                            && searchModel.OrderBy != null ? searchModel.OrderType : OrderTypes.Desc.ToString();
            searchModel.OrderBy = tProperties.Exists(p => p.Name == searchModel.OrderBy) ? searchModel.OrderBy : tProperties.First().Name;
            source = source.OrderBy($"{searchModel.OrderBy} {searchModel.OrderType}");

            
            return new PaginatedList<T>(source, searchModel.PageNumber - 1, searchModel.PageSize);
        }
    }
}
