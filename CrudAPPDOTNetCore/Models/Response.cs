﻿namespace CrudAPPDOTNetCore.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Employee Employee { get; set; }
        public List<Employee> listEmploye { get; set; }
    }
}
