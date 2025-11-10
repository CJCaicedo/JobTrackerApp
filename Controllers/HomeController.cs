// ---------------------------------------------------------
// File: HomeController.cs
// Description: Basic controller responsible for handling  the error page.
// Author: Cindy Johana Caicedo
// ---------------

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
//Returns the error view to display a friendly error page.
    public IActionResult Error()
    {
        return View();
    }
}
