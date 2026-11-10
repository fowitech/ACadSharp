using ACadSharp.Blocks;
using ACadSharp.Entities;
using ACadSharp.IO.Templates;

namespace ACadSharp.IO.DWG
{
	internal partial class DwgObjectReader
	{
		/// <summary>
		/// Offers an entity to <see cref="DwgReaderConfiguration.EntitySink"/>.
		/// </summary>
		/// <returns>True if the sink consumed the entity and it must not be added to the document.</returns>
		private bool offerToEntitySink(CadTemplate template)
		{
			var sink = this._builder.Configuration.EntitySink;
			if (sink == null)
				return false;

			if (template is not CadEntityTemplate entityTemplate || entityTemplate.CadObject is not Entity entity)
				return false;

			//Block markers are needed to build the block records
			if (entity is Block || entity is BlockEnd)
				return false;

			ulong? blockHandle = null;
			bool hasAttributes = false;
			if (template is CadInsertTemplate insertTemplate)
			{
				blockHandle = insertTemplate.BlockHeaderHandle;
				hasAttributes = insertTemplate.HasAtts;
			}

			return sink(new DwgStreamedEntity(
				entity,
				entityTemplate.OwnerHandle,
				entityTemplate.LayerHandle,
				entityTemplate.LineTypeHandle,
				entityTemplate.EntityMode,
				blockHandle,
				hasAttributes));
		}
	}
}
