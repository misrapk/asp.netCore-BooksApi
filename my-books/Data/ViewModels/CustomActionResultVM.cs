﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_books.Data.Models;

namespace my_books.Data.ViewModels
{
	public class CustomActionResultVM
	{
		public Exception Exception { get; set; }
		public Publisher Publisher
		{ get; set; }
	}
}
