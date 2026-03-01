using System;
using System.Collections.Generic;
using System.Text;

namespace Utbildningsföretag.Applikation.DTOs
{
   public record CreateDeltagareDto(
        string FullName,
        string Email
    );
}
