using System;
using System.Data;
using System.IO;
using System.Security;
using System.Text;

namespace benshop.Helpers
{
    public static class ReportHelper
    {
        public static Stream GenerateRdlc(string dataSetName, DataTable data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<Report xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition\"");
            sb.AppendLine("        xmlns:rd=\"http://schemas.microsoft.com/SQLServer/reporting/reportdesigner\">");
            sb.AppendLine("  <DataSources>");
            sb.AppendLine("    <DataSource Name=\"DataSource1\">");
            sb.AppendLine("      <ConnectionProperties><DataProvider>SQL</DataProvider><ConnectString /></ConnectionProperties>");
            sb.AppendLine("    </DataSource>");
            sb.AppendLine("  </DataSources>");
            sb.AppendLine("  <DataSets>");
            sb.AppendLine("    <DataSet Name=\"" + EscapeXml(dataSetName) + "\">");
            sb.AppendLine("      <Query><DataSourceName>DataSource1</DataSourceName><CommandText /></Query>");
            sb.AppendLine("      <Fields>");
            foreach (DataColumn col in data.Columns)
            {
                string columnName = EscapeXml(col.ColumnName);
                sb.AppendLine("        <Field Name=\"" + columnName + "\">");
                sb.AppendLine("          <DataField>" + columnName + "</DataField>");
                sb.AppendLine("          <rd:TypeName>" + GetRdlType(col.DataType) + "</rd:TypeName>");
                sb.AppendLine("        </Field>");
            }
            sb.AppendLine("      </Fields>");
            sb.AppendLine("    </DataSet>");
            sb.AppendLine("  </DataSets>");
            sb.AppendLine("  <ReportSections>");
            sb.AppendLine("    <ReportSection>");
            sb.AppendLine("      <Body>");
            sb.AppendLine("        <ReportItems>");
            sb.AppendLine("          <Tablix Name=\"tbl1\">");
            sb.AppendLine("            <TablixBody>");
            sb.AppendLine("              <TablixColumns>");
            foreach (DataColumn col in data.Columns)
                sb.AppendLine("                <TablixColumn><Width>1.5in</Width></TablixColumn>");
            sb.AppendLine("              </TablixColumns>");
            sb.AppendLine("              <TablixRows>");
            sb.AppendLine("                <TablixRow>");
            sb.AppendLine("                  <Height>0.3in</Height>");
            sb.AppendLine("                  <TablixCells>");
            foreach (DataColumn col in data.Columns)
            {
                string columnName = EscapeXml(col.ColumnName);
                sb.AppendLine("                    <TablixCell>");
                sb.AppendLine("                      <CellContents>");
                sb.AppendLine("                        <Textbox Name=\"h_" + columnName + "\">");
                sb.AppendLine("                          <Paragraphs><Paragraph><TextRuns><TextRun>");
                sb.AppendLine("                            <Value>" + columnName + "</Value>");
                sb.AppendLine("                          </TextRun></TextRuns><Style><TextAlign>Center</TextAlign></Style></Paragraph></Paragraphs>");
                sb.AppendLine("                          <Style><VerticalAlign>Middle</VerticalAlign></Style>");
                sb.AppendLine("                        </Textbox>");
                sb.AppendLine("                      </CellContents>");
                sb.AppendLine("                    </TablixCell>");
            }
            sb.AppendLine("                  </TablixCells>");
            sb.AppendLine("                </TablixRow>");
            sb.AppendLine("                <TablixRow>");
            sb.AppendLine("                  <Height>0.25in</Height>");
            sb.AppendLine("                  <TablixCells>");
            foreach (DataColumn col in data.Columns)
            {
                string columnName = EscapeXml(col.ColumnName);
                sb.AppendLine("                    <TablixCell>");
                sb.AppendLine("                      <CellContents>");
                sb.AppendLine("                        <Textbox Name=\"d_" + columnName + "\">");
                sb.AppendLine("                          <Paragraphs><Paragraph><TextRuns><TextRun>");
                sb.AppendLine("                            <Value>=Fields!" + columnName + ".Value</Value>");
                sb.AppendLine("                          </TextRun></TextRuns><Style><TextAlign>Center</TextAlign></Style></Paragraph></Paragraphs>");
                sb.AppendLine("                          <Style><VerticalAlign>Middle</VerticalAlign></Style>");
                sb.AppendLine("                        </Textbox>");
                sb.AppendLine("                      </CellContents>");
                sb.AppendLine("                    </TablixCell>");
            }
            sb.AppendLine("                  </TablixCells>");
            sb.AppendLine("                </TablixRow>");
            sb.AppendLine("              </TablixRows>");
            sb.AppendLine("            </TablixBody>");
            sb.AppendLine("              <TablixColumnHierarchy>");
            sb.AppendLine("                <TablixMembers>");
            for (int i = 0; i < data.Columns.Count; i++)
                sb.AppendLine("                  <TablixMember />");
            sb.AppendLine("                </TablixMembers>");
            sb.AppendLine("              </TablixColumnHierarchy>");
            sb.AppendLine("              <TablixRowHierarchy>");
            sb.AppendLine("                <TablixMembers>");
            sb.AppendLine("                  <TablixMember />");
            sb.AppendLine("                  <TablixMember />");
            sb.AppendLine("                </TablixMembers>");
            sb.AppendLine("              </TablixRowHierarchy>");
            sb.AppendLine("            <DataSetName>" + EscapeXml(dataSetName) + "</DataSetName>");
            sb.AppendLine("          </Tablix>");
            sb.AppendLine("        </ReportItems>");
            sb.AppendLine("        <Height>2in</Height>");
            sb.AppendLine("      </Body>");
            sb.AppendLine("      <Width>8in</Width>");
            sb.AppendLine("      <Page>");
            sb.AppendLine("        <PageHeight>11in</PageHeight>");
            sb.AppendLine("        <PageWidth>8.5in</PageWidth>");
            sb.AppendLine("        <LeftMargin>0.5in</LeftMargin>");
            sb.AppendLine("        <RightMargin>0.5in</RightMargin>");
            sb.AppendLine("        <TopMargin>0.5in</TopMargin>");
            sb.AppendLine("        <BottomMargin>0.5in</BottomMargin>");
            sb.AppendLine("      </Page>");
            sb.AppendLine("    </ReportSection>");
            sb.AppendLine("  </ReportSections>");
            sb.AppendLine("</Report>");

            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return new MemoryStream(bytes);
        }

        private static string EscapeXml(string value)
        {
            return SecurityElement.Escape(value) ?? string.Empty;
        }

        private static string GetRdlType(Type type)
        {
            if (type == typeof(int) || type == typeof(long) || type == typeof(short))
                return "System.Int32";
            if (type == typeof(decimal) || type == typeof(double) || type == typeof(float))
                return "System.Decimal";
            if (type == typeof(DateTime))
                return "System.DateTime";
            if (type == typeof(bool))
                return "System.Boolean";
            return "System.String";
        }
    }
}
