# Building a Note API 📒

## Models

### Note
```csharp
public class NoteDto
{
	public int Id { get; set; }
	public string Text { get; set; }
	public string Color { get; set; }
	public int Tag { get; set; }
	public int UserId { get; set; }
}

public class NoteModel
{
	public int Id { get; set; }
	public string Text { get; set; }
	public string Color { get; set; }
	public Tag Tag { get; set; }
	public int UserId { get; set; }
}
public enum Tag
{
	Work = 1,
	Education,
	Home,
	Sport,
	Misc,
	Other
}
```
### User
```csharp
public class UserDto
{
	public int Id { get; set; }
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Password { get; set; }
}

public class UserModel
{
	public int Id { get; set; }
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
```
