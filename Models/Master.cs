﻿namespace _7semester_ASP_ThirdTask
{
	public class Master
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public List<Slave>? Slaves { get; set; } = new();
	}
}