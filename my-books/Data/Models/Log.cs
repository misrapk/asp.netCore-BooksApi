﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
	public class Log
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public string MessageTemplate { get; set; }
		public string Level { get; set; }
		public DateTime TimeStamp { get; set; }
		public string Exceptions { get; set; }
		public string Properties { get; set; }
		public string LogEvent { get; set; }
	}

}
