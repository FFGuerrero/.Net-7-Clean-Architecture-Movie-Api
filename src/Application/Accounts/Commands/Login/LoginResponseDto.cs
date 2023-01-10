using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Accounts.Commands.Login;
public class LoginResponseDto
{
    public string Token { get; set; } = default!;
    public DateTime? Expires { get; set; }
}