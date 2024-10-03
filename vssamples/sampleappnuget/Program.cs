using Newtonsoft.Json;

var person = new Person
{
    Name = "Vikash Verma",
    Age = 42,
    Email = "vikash.verma@xyz.com"
};
var json = JsonConvert.SerializeObject(person);
Console.WriteLine(json);

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
