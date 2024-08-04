using UnityEditor;

namespace IronSourceRoot.IronSource.Editor
{
	public interface IAdapterSettings
	{
		void updateProject(BuildTarget buildTarget, string projectPath);
		void updateProjectPlist(BuildTarget buildTarget, string plistPath);
	}
}