using System;
using System.Collections.Generic;
using System.Text;

namespace Utbildningsföretag.Applikation.DTOs
{
 public record RegistreraDeltagareDto(
    Guid ParticipantId,
    Guid CourseSessionId
    );
}
