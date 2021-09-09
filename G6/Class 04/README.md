# Building a Note API 📒

## Models

### Note
```csharp

public class NoteModel
{
	public int Id { get; set; }
	public string Text { get; set; }
	public string Color { get; set; }
	public TagType Tag { get; set; }
        public List<Tag> Tags { get; set; }
}
public class  TagType
{
	public string Name { get; set; }
        public string Color { get; set; }
}

