﻿using DataRepoCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDataAccessLayer.Entity {
    public class PickingOrderEntity {
        /// <summary>
        /// The unique id of the picking-order
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The employee that is assigned.
        /// </summary>
        public EmployeeEntity? Employee { get; set; }

        /// <summary>
        /// The priority of the picking-order.
        /// </summary>
        public byte Priority { get; set; }

        /// <summary>
        /// A not for the picking order.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// The positions of the order.
        /// </summary>
        public ICollection<PickingOrderPositionEntity>? Positions { get; set; }

        /// <summary>
        /// The version for Optimistic Concurrency as inspried by: 
        /// https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations
        /// </summary>
        [Timestamp]
        public byte[] Version { get; set; }

        public PickingOrderEntity(int id, byte priority, string note) {
            Id = id;
            Priority = priority;
            Note = note;
        }

        public PickingOrderEntity(PickingOrder pickingOrder) {
            Id = pickingOrder.Id;
            Priority = pickingOrder.Priority; 
            Note = pickingOrder.Note; 
        }

        public PickingOrder MapToDataModel() {
            var list = new List<PickingOrderPosition>();
            foreach(var e in Positions) {
                list.Add(e.MapToDataModel());
            }

            return new PickingOrder() { Id = Id, Assignee = Employee?.MapToDataModel(), Note = Note, Priority = Priority, OrderPositions = list};
        }
        
    }
}
