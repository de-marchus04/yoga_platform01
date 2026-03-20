namespace Yoga.Shared.DTOs
{
    public enum ContentFieldType
    {
        Text,
        TextArea,
        RichText,
        Image
    }

    public record ContentField(
        string Key,
        string Label,
        ContentFieldType Type = ContentFieldType.Text,
        string? Group = null,
        string? Placeholder = null
    );
}
