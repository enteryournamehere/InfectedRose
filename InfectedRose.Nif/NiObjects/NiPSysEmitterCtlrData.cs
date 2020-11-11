using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system emitter controller data.
	///         
	/// </summary>
	public class NiPSysEmitterCtlrData : NiObject
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public KeyGroup<float> FloatKeys { get; set; } 
		
		/// <summary>
		/// Number of keys.
		/// </summary>
		public uint NumVisibilityKeys { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Key<byte>[] VisibilityKeys { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			FloatKeys = new KeyGroup<float>();
			FloatKeys.Deserialize(reader);
			
			NumVisibilityKeys = reader.Read<uint>();
			
			VisibilityKeys = new Key<byte>[NumVisibilityKeys];
			for (var i = 0; i < NumVisibilityKeys; i++)
			{
				var value = new Key<byte>();
				value.Deserialize(reader);
				VisibilityKeys[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(FloatKeys);
			
			writer.Write(NumVisibilityKeys);
			
			for (var i = 0; i < NumVisibilityKeys; i++)
			{
				writer.Write(VisibilityKeys[i]);
			}
			
		}
	}
	

}
