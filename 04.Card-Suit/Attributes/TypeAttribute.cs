using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class TypeAttribute : Attribute
{
    private string type;
    private string category;
    private string description;

    public TypeAttribute(string type, string category, string description)
    {
        this.type = type;
        this.category = category;
        this.description = description;
    }

    public string Type { get { return this.type; } }

    public string Category {get { return this.category; } }

    public string Description { get { return this.description; } }

    public override string ToString()
    {
        return $"Type = {this.type}, Description = {this.description}";
    }
}
