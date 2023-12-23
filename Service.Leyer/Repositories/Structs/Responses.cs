using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Leyer.Repositories.Structs;

public struct Responses<T>
{
    public bool HasError { get; set; }
    public string ErrorMessage { get; set; }
    public string Message { get; set; }
    public IEnumerable<T> Data { get; set; }

}