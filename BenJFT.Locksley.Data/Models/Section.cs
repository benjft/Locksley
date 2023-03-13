using BenJFT.Locksley.Data.Enums;

namespace BenJFT.Locksley.Data.Models;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public record Section {
    public int SectionId { get; set; }

    public int SectionNumber { get; set; }

    public int Distance { get; set; }

    public LengthUnits DistanceUnits { get; set; } = LengthUnits.Meters;

    public int TargetFaceId { get; set; }

    public virtual TargetFace TargetFace { get; set; } = default!;

    public virtual ICollection<End> Ends { get; set; } = new List<End>();
}