﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSharp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Test : ControllerBase
	{ 
		[HttpGet]
		public string Get()
		{
			return "Success!";
		}
	}
}
