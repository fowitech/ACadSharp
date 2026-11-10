using System;

namespace ACadSharp.IO;

/// <summary>
/// Configuration for reading DWG files.
/// </summary>
public class DwgReaderConfiguration : CadReaderConfiguration
{
	/// <summary>
	/// Use the Standard Cycling Redundancy Check to verify the integrity of the file, default value is set to false.
	/// </summary>
	/// <remarks>
	/// DWG file format uses a modification of a standard Cyclic Redundancy Check as an error detecting mechanism, 
	/// if this flag is enabled the reader will perform this verification to detect any possible error, but it will greatly increase the reading time.
	/// </remarks>
	[Obsolete("This property is obsolete and will be removed in future versions.")]
	public bool CrcCheck { get; set; } = false;

	/// <summary>
	/// If set to false the reader will skip the summary info section.
	/// </summary>
	/// <value>
	/// default: true
	/// </value>
	public bool ReadSummaryInfo { get; set; } = true;

	/// <summary>
	/// Optional sink that receives every entity as soon as it is read, before the document is built.
	/// </summary>
	/// <remarks>
	/// If the sink returns true the entity is consumed: it is not added to the document, so very large
	/// files can be processed without holding all their entities in memory. Entities consumed this way
	/// are missing from the resulting <see cref="CadDocument"/>; tables and block records are still built.
	/// Block begin and end markers are never offered to the sink.
	/// </remarks>
	/// <value>
	/// default: null
	/// </value>
	public Func<DwgStreamedEntity, bool> EntitySink { get; set; }
}
