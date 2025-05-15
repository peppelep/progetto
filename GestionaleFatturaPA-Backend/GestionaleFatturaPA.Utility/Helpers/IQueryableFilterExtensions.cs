using GestionaleFatturaPA.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Utility.Helpers
{
    public static class IQueryableFilterExtensions
    {
        public static FilterQueryResult<T> WhereDynamicFilters<T>(
                                    this IQueryable<T> source,
                                    List<FieldFilter> fieldFilters,
                                    int pageIndex = 0,
                                    int pageSize = 0)
        {
            if (fieldFilters == null || fieldFilters.Count == 0)
                return new FilterQueryResult<T>(source,source.Count());

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? body = null;

            foreach (var filter in fieldFilters)
            {
                // Salta il filtro se il valore è vuoto o solo spazi bianchi
                if (string.IsNullOrWhiteSpace(filter.Value))
                    continue;

                // Accede alla proprietà dell'oggetto T corrispondente al filtro
                var property = Expression.PropertyOrField(parameter, filter.Field);

                // Converte la proprietà in stringa per semplificare il confronto
                var toStringCall = Expression.Call(property, "ToString", Type.EmptyTypes);
                var filterConstant = Expression.Constant(filter.Value, typeof(string));

                Expression condition;

                // Determina il tipo di confronto in base all'operatore indicato
                var operatore = filter.Operator?.ToLowerInvariant();
                if (operatore == "equals")
                {
                    // Confronto di uguaglianza
                    condition = Expression.Equal(toStringCall, filterConstant);
                }
                else if (operatore == "startswith")
                {
                    // Confronto con StartsWith
                    var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!;
                    condition = Expression.Call(toStringCall, startsWithMethod, filterConstant);
                }
                else
                {
                    // Operatore di default: Contains
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                    condition = Expression.Call(toStringCall, containsMethod, filterConstant);
                }

                // Combina i filtri tramite AND logico
                body = body == null ? condition : Expression.AndAlso(body, condition);
            }

            if (body == null)
                return new FilterQueryResult<T>(source, source.Count());

            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
            var filteredQuery = source.Where(predicate);
            var count = filteredQuery.Count();

            // Applica la paginazione se pageIndex e pageSize sono maggiori di 0
            if (pageIndex > 0 && pageSize > 0)
            {
                int skip = (pageIndex - 1) * pageSize;
                filteredQuery = filteredQuery.Skip(skip).Take(pageSize);
            }

            return new FilterQueryResult<T>(filteredQuery, count); ;
        }

    }

}
