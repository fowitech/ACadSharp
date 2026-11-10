using ACadSharp.Entities;

namespace ACadSharp.IO;

/// <summary>
/// An entity handed to <see cref="DwgReaderConfiguration.EntitySink"/> as soon as it is read.
/// </summary>
/// <remarks>
/// The document is not built at this point, so references to other objects are given as handles
/// and the properties of <see cref="Entity"/> that point to other objects (layer, owner, block) are not set.
/// </remarks>
public readonly struct DwgStreamedEntity
{
	/// <summary>
	/// The entity with its own data read; references to other objects are not resolved.
	/// </summary>
	public Entity Entity { get; }

	/// <summary>
	/// Handle of the owner: a block record, or the parent entity for vertices and attributes.
	/// Null when the owner is implied by <see cref="EntityMode"/>.
	/// </summary>
	public ulong? OwnerHandle { get; }

	/// <summary>
	/// Handle of the layer.
	/// </summary>
	public ulong? LayerHandle { get; }

	/// <summary>
	/// Handle of the line type, null when it is ByLayer, ByBlock or Continuous.
	/// </summary>
	public ulong? LineTypeHandle { get; }

	/// <summary>
	/// 0: owned by the object in <see cref="OwnerHandle"/>, 1: paper space, 2: model space.
	/// </summary>
	public byte EntityMode { get; }

	/// <summary>
	/// For an <see cref="Insert"/>, handle of the block record it references; otherwise null.
	/// </summary>
	public ulong? BlockHandle { get; }

	/// <summary>
	/// For an <see cref="Insert"/>, true when attribute entities follow it.
	/// </summary>
	public bool HasAttributes { get; }

	internal DwgStreamedEntity(
		Entity entity,
		ulong? ownerHandle,
		ulong? layerHandle,
		ulong? lineTypeHandle,
		byte entityMode,
		ulong? blockHandle,
		bool hasAttributes)
	{
		this.Entity = entity;
		this.OwnerHandle = ownerHandle;
		this.LayerHandle = layerHandle;
		this.LineTypeHandle = lineTypeHandle;
		this.EntityMode = entityMode;
		this.BlockHandle = blockHandle;
		this.HasAttributes = hasAttributes;
	}
}
