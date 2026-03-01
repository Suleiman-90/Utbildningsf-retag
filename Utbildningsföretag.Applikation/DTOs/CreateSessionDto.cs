using System;
using System.Collections.Generic;
using System.Text;

namespace Utbildningsföretag.Applikation.DTOs
{
  public record CreateSessionDto(
       Guid CourseId,
       Guid TeacherId,
        DateTime StartDate,
        DateTime EndDate

    );
}
