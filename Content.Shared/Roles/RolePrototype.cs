using Robust.Shared.Prototypes;

namespace Content.Shared.Roles;

/// <summary>
/// Describes information for a single role on the station.
/// </summary>
[Prototype]
public abstract partial class RolePrototype : IPrototype
{
    [ViewVariables]
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    ///     The playtime that will be tracked while this role.
    /// </summary>
    [DataField("playTimeTracker", required: true)]
    public string PlayTimeTracker { get; private set; } = string.Empty;

    /// <summary>
    ///     The name of this role as displayed to players.
    /// </summary>
    [DataField("name")]
    public string Name { get; private set; } = string.Empty;

    [ViewVariables(VVAccess.ReadOnly)]
    public string LocalizedName => Loc.GetString(Name);

    /// <summary>
    ///     Requirements for the role.
    /// </summary>
    [DataField, Access(typeof(SharedRoleSystem), Other = AccessPermissions.None)]
    public HashSet<JobRequirement>? Requirements;

    /// <summary>
    ///     Color displayed for the role. Takes precedent over department color
    /// </summary>
    [DataField]
    public Color? Color;
}
