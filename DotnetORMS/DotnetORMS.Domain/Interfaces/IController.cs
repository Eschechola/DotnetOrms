using DotnetORMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetORMS.Interfaces
{
    public interface IController
    {
        IActionResult Insert([FromBody]User user);
        IActionResult Update([FromBody]User user);
        IActionResult Delete(int id);
        IActionResult Get(int id);
        IActionResult GetAll();
    }
}
