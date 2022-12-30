using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Text.Json;

/*
[{
"id":1,
"first_name":"Cozmo",
"last_name":"Healing",
"email":"chealing0@cloudflare.com",
"gender":"Male",
"ip_address":"156.125.14.208"
},
*/

var incoming = new List<Person>();

using(StreamReader recs = new StreamReader("customers.json"))
{
    string json = recs.ReadToEnd();
    incoming = JsonSerializer.Deserialize<List<Person>>(json);
}

if(incoming != null && incoming.Count > 0)
{
    foreach(var customer in incoming)
    {
        Console.WriteLine($"{customer.first_name}, {customer.last_name}\n");
        Console.Write($"ID, {customer.id}\nEmail, {customer.email}\nip_address, {customer.ip_address}");
    }

    Console.WriteLine("\0There are {0} total recrods", incoming.Count);
}

public record struct Person(
    int id,
    string first_name,
    string last_name,
    string email,
    string gender,
    string ip_address
);