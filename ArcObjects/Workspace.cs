using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing.ArcObjects
{
    public static class Workspace
    {
        public static ESRI.ArcGIS.Geodatabase.IWorkspace GetWorkspace(string sPath, ESRI.ArcGIS.Geodatabase.esriDatasetType eDataType)
        {
            Type pFatoryType = null;

            switch (eDataType)
            {
                case ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureClass:
                    if (sPath.Contains(".gdb"))
                    {
                        pFatoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");
                    }
                    else
                    {
                        pFatoryType = Type.GetTypeFromProgID("esriDataSourcesFile.ShapefileWorkspaceFactory");
                    }
                    break;
                
                default:
                    //esriDataSourcesGDB.AccessWorkspaceFactory 
                    //esriDataSourcesFile.ArcInfoWorkspaceFactory 
                    //esriDataSourcesFile.CadWorkspaceFactory 
                    //esriDataSourcesGDB.FileGDBWorkspaceFactory 
                    //esriDataSourcesOleDB.OLEDBWorkspaceFactory 
                    //esriDataSourcesFile.PCCoverageWorkspaceFactory 
                    //esriDataSourcesRaster.RasterWorkspaceFactory 
                    //esriDataSourcesGDB.SdeWorkspaceFactory 
                    //esriDataSourcesFile.ShapefileWorkspaceFactory 
                    //esriDataSourcesOleDB.TextFileWorkspaceFactory 
                    //esriDataSourcesFile.TinWorkspaceFactory 
                    //esriDataSourcesFile.VpfWorkspaceFactory
                    break;
            }

            ESRI.ArcGIS.Geodatabase.IWorkspaceFactory2 pWorkspaceFactory = (ESRI.ArcGIS.Geodatabase.IWorkspaceFactory2)Activator.CreateInstance(pFatoryType);            
            return pWorkspaceFactory.OpenFromFile(sPath, 0);
        }

        public static ESRI.ArcGIS.Geodatabase.IFeatureClass Testing(string sPath,
                                                                    ESRI.ArcGIS.Geometry.esriGeometryType eGeometryType)
        {
            string sDirectory = System.IO.Path.GetDirectoryName(sPath);
            string sFeatureClassName = System.IO.Path.GetFileName(sPath);
            ESRI.ArcGIS.Geodatabase.IWorkspace pWorkspace = ArcObjects.Workspace.GetWorkspace(sDirectory, ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureClass);
            ESRI.ArcGIS.Geodatabase.IFeatureWorkspace pFeatureWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)pWorkspace;

            ESRI.ArcGIS.Geodatabase.IFeatureClassDescription pFeatureClassDescription = new ESRI.ArcGIS.Geodatabase.FeatureClassDescriptionClass();
            ESRI.ArcGIS.Geodatabase.IObjectClassDescription pObjectClassDescription = (ESRI.ArcGIS.Geodatabase.IObjectClassDescription)pFeatureClassDescription;
            ESRI.ArcGIS.Geodatabase.IFields pFields = pObjectClassDescription.RequiredFields;

            int iShapeFieldIndex = pFields.FindField(pFeatureClassDescription.ShapeFieldName);
            ESRI.ArcGIS.Geodatabase.IField pShapeField = pFields.get_Field(iShapeFieldIndex);
            ESRI.ArcGIS.Geodatabase.IGeometryDef pGeometryDefinition = pShapeField.GeometryDef;
            ESRI.ArcGIS.Geodatabase.IGeometryDefEdit pGeometryDefinitionEdit = (ESRI.ArcGIS.Geodatabase.IGeometryDefEdit)pGeometryDefinition;
            pGeometryDefinitionEdit.GeometryType_2 = eGeometryType;

            ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatureClass = pFeatureWorkspace.CreateFeatureClass(sFeatureClassName,
                                                                                                        pFields,
                                                                                                        pObjectClassDescription.InstanceCLSID,
                                                                                                        pObjectClassDescription.ClassExtensionCLSID,
                                                                                                        ESRI.ArcGIS.Geodatabase.esriFeatureType.esriFTSimple,
                                                                                                        pFeatureClassDescription.ShapeFieldName, "");
            return pFeatureClass;
        }

        public static void FieldStuff(ESRI.ArcGIS.Geodatabase.IFeatureWorkspace pFeatureWorkspace)
        {
            ESRI.ArcGIS.Geodatabase.IFields pFields = new ESRI.ArcGIS.Geodatabase.FieldsClass();
            ESRI.ArcGIS.Geodatabase.IFieldsEdit pFieldsEdit = (ESRI.ArcGIS.Geodatabase.IFieldsEdit)pFields;
            ESRI.ArcGIS.Geodatabase.IField pField = new ESRI.ArcGIS.Geodatabase.FieldClass();
            ESRI.ArcGIS.Geodatabase.IFieldEdit pFieldEdit = (ESRI.ArcGIS.Geodatabase.IFieldEdit)pField;

            //validate fields
            ESRI.ArcGIS.Geodatabase.IFieldChecker pFieldChecker = new ESRI.ArcGIS.Geodatabase.FieldCheckerClass();
            ESRI.ArcGIS.Geodatabase.IEnumFieldError pEnumFieldError = null;
            ESRI.ArcGIS.Geodatabase.IFields pValidatedFields = null;
            pFieldChecker.ValidateWorkspace = (ESRI.ArcGIS.Geodatabase.IWorkspace)pFeatureWorkspace;
            pFieldChecker.Validate(pFields, out pEnumFieldError, out pValidatedFields);

        }

        public static void LoopOverProjections()
        {

            ESRI.ArcGIS.Geometry.ISpatialReferenceFactory pSpatialRefFactory = new ESRI.ArcGIS.Geometry.SpatialReferenceEnvironmentClass();
            ESRI.ArcGIS.esriSystem.ISet pProjectionSet = pSpatialRefFactory.CreatePredefinedProjections();

            System.Windows.Forms.MessageBox.Show(String.Format("Projections: {0}", pProjectionSet.Count));
            pProjectionSet.Reset();

            for (int i = 0; i < pProjectionSet.Count -1; i++)
            {
                ESRI.ArcGIS.Geometry.IProjection pProjection = pProjectionSet.Next() as ESRI.ArcGIS.Geometry.IProjection;
                System.Windows.Forms.MessageBox.Show(pProjection.Name);
            }

        }

    }
}
