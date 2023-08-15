﻿using Masuit.Tools.AspNetCore.ModelBinder;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NetCoreTest.Controllers;

[ApiController]
public class HomeController : Controller
{
	[HttpPost("test")]
	[ProducesResponseType(typeof(MyClass), (int)HttpStatusCode.OK)]
	public async Task<ActionResult> Test([FromBodyOrDefault] MyClass mc, [FromBodyOrDefault(BindType.Body | BindType.Query)] string name)
	{
		return Ok(new
		{
			name,
			mc
		});
	}
}

public class MyClass
{
	public string MyProperty { get; set; }

	public List<string> List { get; set; }
}
