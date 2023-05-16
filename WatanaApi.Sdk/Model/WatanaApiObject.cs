using System;
namespace WatanaApi.Sdk.Model
{
	public class WatanaApiValue{
		public string Key { get; set; }
		public object Value { get; set; }
		public WatanaApiValue(string key, object value) {
			Key = key;
			Value = value;
		}
    }
	public class WatanaApiObject : Dictionary<string, object>
	{
		public WatanaApiObject()
		{
		}

        public WatanaApiObject(List<WatanaApiValue> values)
        {
			foreach (var dt in values)
				Add(dt.Key, dt.Value);
        }

        public void Add(string key, object value) {
		
			Type t = value.GetType();
			if (t == typeof(FileStream)) {
				var file = value as FileStream;
				var ziped = Util.Util.Zip(Util.Util.StreamToBytes(file));
                base.Add(key, ziped);
            }
            else
                base.Add(key, value);
        }

		public bool ValidarObligatorio(string name) {
			if (!this.ContainsKey(name)) {
				throw new ErrorCampoOblogatorio(name);
			}
			return true;
		}
	}

    
}

