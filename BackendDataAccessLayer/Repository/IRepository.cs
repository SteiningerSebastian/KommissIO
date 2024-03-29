﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackendDataAccessLayer.Repository {
    /// <summary>
    /// The interfaces used for all repositories in the project.
    /// </summary>
    /// <typeparam name="T">The generic datatype of the datamodel of the repository.</typeparam>
    public interface IRepository<T> : IDisposable {
        /// <summary>
        /// Get all elements of the repository.
        /// </summary>
        /// <returns>Returns a enumerable containing all elements of the repository.</returns>
        Task<IEnumerable<T>> GetElementsAsync();

        /// <summary>
        /// Get an element by its id.
        /// </summary>
        /// <param name="id">The element id which is requested.</param>
        /// <returns>Returns the element if found, otherwise null.</returns>
        Task<T?> GetElementByIDAsync(int id);

        /// <summary>
        /// Insert an element into the repository.
        /// </summary>
        /// <param name="element">The element to insert.</param>
        Task InsertAsync(T element);

        /// <summary>
        /// Insert elements into the repository.
        /// </summary>
        /// <param name="elements">The elements to insert.</param>
        Task InsertRangeAsync(IEnumerable<T> elements);

        /// <summary>
        /// Delete an element using its id.
        /// </summary>
        /// <param name="id">The id of the element to remove from the repository.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Update a given element.
        /// </summary>
        /// <param name="element">The element to update</param>
        Task UpdateAsync(T element);

        /// <summary>
        /// Select entities from the repository.
        /// </summary>
        /// <param name="selector">The function that checks if the element should be included.</param>
        /// <returns>Returns an enumerable containing the selected entries.</returns>
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> selector);

        /// <summary>
        /// Find the entity from the repository.
        /// </summary>
        /// <param name="selector">The function that checks if the element should be selected.</param>
        /// <returns>Returns the found element, first.</returns>
        Task<T?> FindAsync(Expression<Func<T, bool>> selector);

        /// <summary>
        /// Count the elments that meet the specified criteria.
        /// </summary>
        /// <param name="selector">A function checking if the element should be counted.</param>
        /// <returns>Returns the amount of elements matching the cretirea.</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> selector);

        /// <summary>
        /// Reset the data to some default data.
        /// </summary>
        Task ResetAsync();
    }
}
