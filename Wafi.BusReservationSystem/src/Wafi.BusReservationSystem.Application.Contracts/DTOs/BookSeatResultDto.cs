using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wafi.BusReservationSystem.Application.Contracts.DTOs
{
    public class BookSeatResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Guid? TicketId { get; set; }
    }
}
