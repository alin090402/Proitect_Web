﻿namespace WorkForever.Helpers.Exceptions;

public class DataNotFoundException:Exception
{
    public DataNotFoundException(string message):base(message)
    {
    }
}