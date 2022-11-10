﻿namespace ResolutionActionSystem.Application.Responses
{
    public class BaseCommandResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Error { get; set; }
    }
}
