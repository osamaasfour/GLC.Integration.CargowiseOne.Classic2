namespace GLC.Integration.CargowiseOne.Classic2.Schemas.outbound {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945", typeof(global::GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945))]
    public sealed class TransformUniversalShipmentToEDI945 : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:ns0=""http://schemas.microsoft.com/BizTalk/EDI/X12/2006"" xmlns:s0=""http://www.cargowise.com/Schemas/Universal/2011/11"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"" xmlns:ScriptNS0=""http://schemas.microsoft.com/BizTalk/2003/ScriptNS0"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:UniversalShipment"" />
  </xsl:template>
  <xsl:template match=""/s0:UniversalShipment"">
    <xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot; CL&quot;)"" />
    <xsl:variable name=""var:v4"" select=""userCSharp:StringConcat(&quot;WH&quot;)"" />
    <xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;ClassicBrands c/o GLC&quot;)"" />
    <ns0:X12_00401_945>
      <ns0:W06>
        <W0602>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:ClientReference/text()"" />
        </W0602>
        <xsl:for-each select=""s0:Shipment/s0:DataContext"">
          <xsl:for-each select=""s0:EventType"">
            <xsl:variable name=""var:v1"" select=""userCSharp:LogicalEq(string(s0:Code/text()) , &quot;FIN&quot;)"" />
            <xsl:if test=""string($var:v1)='true'"">
              <xsl:variable name=""var:v2"" select=""userCSharp:Getdateformat(../s0:TriggerDate/text())"" />
              <W0603>
                <xsl:value-of select=""$var:v2"" />
              </W0603>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
        <W0604>
           <xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderNumber/text()"" />  
      </W0604>
        <W0605>
           <xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderNumber/text()"" />  
      </W0605>
        <W0611>
          <xsl:value-of select=""$var:v3"" />
        </W0611>
      </ns0:W06>
      <ns0:N1Loop1>
        <ns0:N1>
          <N101>WH</N101>
          <N102>CLASSICBRANDS c/o GDS</N102>
        </ns0:N1>
        <ns0:N3>
          <N301>23647 W EAMES ST</N301>
        </ns0:N3>
        <ns0:N4>
          <N401>CHANNAHON</N401>
          <N402>IL</N402>
          <N403>60410</N403>
          <N404>US</N404>
        </ns0:N4>
      </ns0:N1Loop1>

      <ns0:N1Loop1>
        <ns0:N1>
          <N101>SF</N101>
          <N102>CLASSICBRANDS c/o GDS</N102>
        </ns0:N1>
        <ns0:N3>
          <N301>23647 W EAMES ST</N301>
        </ns0:N3>
        <ns0:N4>
          <N401>CHANNAHON</N401>
          <N402>IL</N402>
          <N403>60410</N403>
          <N404>US</N404>
        </ns0:N4>
      </ns0:N1Loop1>
      
      <xsl:variable name=""varn904"">
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='N1*ST*04'"">
              <xsl:value-of select=""s0:Value/text()""/>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
       </xsl:variable>


              <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
        <xsl:if test=""s0:AddressType/text()='ConsigneeAddress'"">
          <ns0:N1Loop1>
            <ns0:N1>
              <N101>
                <xsl:text>ST</xsl:text>
              </N101>
              <N102>
                <xsl:value-of select=""s0:CompanyName/text()"" />
              </N102>
              
                <N104>
                  <xsl:value-of select=""$varn904""></xsl:value-of>         
                </N104>
            </ns0:N1>
            <ns0:N3>
              <N301>
                <xsl:value-of select=""s0:Address1/text()""/>
              </N301>
              <N302>
                <xsl:value-of select=""s0:Address2/text()""/>
              </N302>
            </ns0:N3>
            <ns0:N4>
                  <N401>
                    <xsl:value-of select=""s0:City/text()""/>
                  </N401>
                  <N402>
                    <xsl:value-of select=""s0:State/text()""/>
                  </N402>
                  <N403>
                    <xsl:value-of select=""s0:Postcode/text()""/>
                  </N403>              
                  <N404>
                    <xsl:value-of select=""s0:Country/s0:Code/text()""/>
                </N404>
            </ns0:N4>
                      
          </ns0:N1Loop1>
        
        </xsl:if>               
      </xsl:for-each>

      
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='Department'"">
              <xsl:value-of select=""s0:Value/text()""/>
              <ns0:N9>
                <N901>DP</N901>
               
                    <N902>
                      <xsl:value-of select=""s0:Value/text()""/>
                    </N902>
                    </ns0:N9>
            </xsl:if>
         </xsl:for-each>
         </xsl:for-each>

      <ns0:N9>
        <N901>
          <xsl:text>CN</xsl:text>
        </N901>
        <N902>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:TransportReference/text()""/>
        </N902>
      </ns0:N9>

      <ns0:N9>
        <N901>
          <xsl:text>BM</xsl:text>
        </N901>
        <N902>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderNumber/text()""/>
        </N902>
        </ns0:N9>
       
      <xsl:for-each select=""s0:Shipment/s0:MilestoneCollection/s0:Milestone"">
        
        <xsl:if test=""s0:EventCode/text()='FIN'"">
          <ns0:G62>
            <G6201>
              <xsl:text>11</xsl:text>
            </G6201>
            
            <G6202>
              <xsl:value-of select=""userCSharp:Getdateformat(s0:ActualDate/text())""/>
            </G6202>
            
          </ns0:G62>          
        </xsl:if>
        
      </xsl:for-each>

      <ns0:W27>
            <W2701>
              <xsl:text>M</xsl:text>
            </W2701>
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='SCAC'"">              
            <W2702>
              <xsl:value-of select=""s0:Value/text()""/>
            </W2702>
              </xsl:if>
              </xsl:for-each>
               </xsl:for-each>
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='Routing'"">
              <W2703>
                <xsl:value-of select=""s0:Value/text()""/>
              </W2703>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
          </ns0:W27>
      
  <ns0:LXLoop1>
          <ns0:LX>
            <LX01>1</LX01>
          </ns0:LX>
      <xsl:for-each select=""s0:Shipment/s0:Order/s0:OrderLineCollection/s0:OrderLine"">
       <xsl:variable name=""varprodcodelist"" select =""s0:Product/s0:Code/text()""/>
        
          
          
          <xsl:variable name =""varctn"" select=""s0:QuantityMet/text()""/>
          
         
                                     
             <xsl:variable name=""varVendorvalue"" select=""s0:CustomizedFieldCollection/s0:CustomizedField[1]/s0:Value/text()""/>                         
              <xsl:variable name=""varPartvalue"" select=""s0:CustomizedFieldCollection/s0:CustomizedField[2]/s0:Value/text()""/>
          <xsl:variable name=""varProdVal"" select=""s0:CustomizedFieldCollection/s0:CustomizedField[3]/s0:Value/text()""/>
        <xsl:variable name=""varupsccode"" select=""s0:CustomizedFieldCollection/s0:CustomizedField[4]/s0:Value/text()""/>
        <xsl:variable name=""varbuyerscat"" select=""s0:CustomizedFieldCollection/s0:CustomizedField[5]/s0:Value/text()""/>
                 
          
          <xsl:choose>
          <xsl:when test=""//s0:PackingLineCollection/s0:PackingLine/s0:ReferenceNumber"">
          <xsl:for-each select=""//s0:PackingLineCollection"">
              <xsl:for-each select=""s0:PackingLine"">
                <xsl:for-each select=""s0:PackedItemCollection"">
                  <xsl:for-each select=""s0:PackedItem"">
                    <xsl:variable name=""varcommerciallnk"" select=""s0:CommercialInvoiceLineLink/text()""/>
                    <xsl:variable name=""varProdcode"">
                      <xsl:for-each select=""//s0:CommercialInvoiceLineCollection"">
                        <xsl:for-each select=""s0:CommercialInvoiceLine"">
                          <xsl:variable name=""varcommlink"" select=""s0:Link/text()""/>
                          <xsl:if test=""$varcommerciallnk=$varcommlink"">
                            <xsl:for-each select=""s0:CustomizedFieldCollection"">
                              <xsl:for-each select=""s0:CustomizedField"">
                                <xsl:if test=""s0:Key/text()='Product Code'"">
                                  <xsl:value-of select=""s0:Value/text()""/>
                                </xsl:if>
                              </xsl:for-each>
                            </xsl:for-each>                            
                          </xsl:if>                          
                        </xsl:for-each> 
                      
                      </xsl:for-each>
                    </xsl:variable>
                    <!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>-->
                    <xsl:if test=""$varprodcodelist=$varProdcode"">
                   <ns0:W12Loop1>
                      <ns0:W12>
                        <W1201>
                          <xsl:text>CC</xsl:text>
                        </W1201>
                        <!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>-->
                        <xsl:variable name=""varQuantity"" select =""ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:PackedQuantity/text()))""/>
                        <xsl:value-of select=""userCSharp:addvalue($varQuantity)""/>
                        <W1202>
                          <xsl:value-of select=""$varQuantity""/>
                        </W1202>
                        <!--<xsl:variable name=""varw1203"" select=""ScriptNS0:Get945convPCE(../s0:Product/s0:Code/text(),userCSharp:replacefunc(../s0:QuantityMet/text()))""/>-->
                        <W1203>
                          <xsl:value-of select=""$varQuantity""/>
                        </W1203>
                        <W1204>0</W1204>
                        <W1205>
                          <xsl:text>EA</xsl:text>
                        </W1205>
                        
                            <W1206>
                              <xsl:value-of select=""$varupsccode""/>
                            </W1206>
                         
                        <W1215>
                          <xsl:text>VN</xsl:text>
                        </W1215>
                        <W1216>
                          <xsl:value-of select=""$varprodcodelist""/>
                        </W1216>
                        <W1221>
                          <xsl:text>CB</xsl:text>
                        </W1221>
                       
                          <W1222>
                            <xsl:value-of select=""$varbuyerscat""/>
                          </W1222>
                       
                       
                      </ns0:W12>
                    <ns0:N9_3>
                        <N901>LI</N901>
                          <N902>
                            <xsl:value-of select =""$varProdVal""/>
                    </N902>
                      </ns0:N9_3>
                     <xsl:variable name=""varCTNWeight"" select=""ScriptNS0:Get945convPCEWeight($varProdcode,userCSharp:replacefunc(s0:PackedQuantity/text()))""/>
                     <!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>
                      <xsl:if test=""$varprodcodelist=$varProdcode"">-->
                        <ns0:W27_2>
                          <W2701>
                            <xsl:value-of select=""../../s0:PackType/s0:Code/text()"" />                        
                          </W2701>
                          <xsl:if test=""s0:Description"">
                            <W2702>
                              <xsl:value-of select=""$varProdcode"" />
                            </W2702>
                          </xsl:if>
                          <xsl:if test=""s0:PackedQuantity"">
                            <xsl:variable name=""varQuantity"" select =""ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:PackedQuantity/text()))""/>
                            <W2703>
                              <xsl:value-of select=""$varQuantity"" />
                            </W2703>
                          </xsl:if>
                          <xsl:if test=""../../s0:ReferenceNumber"">
                            <W2704>
                              <xsl:value-of select=""concat('00',../../s0:ReferenceNumber/text())"" />
                            </W2704>
                          </xsl:if>
                          
                       <W2705>
                          <xsl:value-of select=""$varCTNWeight""/>                       
                        </W2705>
                          <W2706>LB</W2706>
                        </ns0:W27_2>                      
                      <!--</xsl:if>-->                       
                    </ns0:W12Loop1>
                     </xsl:if>
                  </xsl:for-each>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
          <ns0:W12Loop1>
            <ns0:W12>
                        <W1201>
                          <xsl:text>CC</xsl:text>
                        </W1201>
                        <xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>
                        <xsl:variable name=""varQuantity"" select=""ScriptNS0:Get945convPCE(s0:Product/s0:Code/text(),userCSharp:replacefunc(s0:QuantityMet/text()))""/>
              <xsl:value-of select=""userCSharp:addvalue($varQuantity)""/>
              <xsl:variable name=""varw1203"" select=""ScriptNS0:Get945convPCE(s0:Product/s0:Code/text(),userCSharp:replacefunc(s0:OrderedQty/text()))""/>
                       <W1202>
                          <xsl:value-of select=""$varw1203""/>
                        </W1202>
                        
                        <W1203>
                          <xsl:value-of select=""$varQuantity""/>
                        </W1203>
                        <W1204>
                          <xsl:value-of select =""userCSharp:getdiff($varw1203,$varQuantity)""/>
                        </W1204>
                        <W1205>
                          <xsl:text>EA</xsl:text>
                        </W1205>
             

              <W1206>
                <xsl:value-of select=""$varupsccode""/>
              </W1206>

              <W1215>
                <xsl:text>VN</xsl:text>
              </W1215>
              <W1216>
                <xsl:value-of select=""$varprodcodelist""/>
              </W1216>
              <W1221>
                <xsl:text>CB</xsl:text>
              </W1221>

              <W1222>
                <xsl:value-of select=""$varbuyerscat""/>
              </W1222>
                      </ns0:W12>
          <ns0:N9_3>
          <N901>LI</N901>
            <N902>
          <xsl:value-of select =""$varProdVal""/>
          </N902>
          </ns0:N9_3>
            </ns0:W12Loop1>
          </xsl:otherwise>
          </xsl:choose> 
        
      </xsl:for-each>
</ns0:LXLoop1>
      <ns0:W03>
        <W0301>
          <xsl:value-of select=""userCSharp:getvalue()""/>
        </W0301>
        <W0302>
          <xsl:value-of select=""userCSharp:getcbconversion(s0:Shipment/s0:Order/s0:TotalNetWeightSent/text())""/>
        </W0302>
        <xsl:value-of select=""userCSharp:resetval()""/>
        <W0303>LB</W0303>
      </ns0:W03>
      
    </ns0:X12_00401_945>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[
    
    public decimal value1=0.0M;
    
     public double getcbconversion(int a)
    {
    double b=0;
      b=Math.Round((a*2.2),2,MidpointRounding.AwayFromZero);
      return b;
      }
    
    
    public void addvalue(decimal a)
    {
      value1=value1+a;           
    }
    
    public decimal getvalue()
    {
    return value1;
    }
    
    public void resetval()
    {
    value1=0.0M;
    }
    
    public int getdiff(int a1,int a2)
    {
         int a11=a1-a2;
         return a11;
    }
    
    public string replacefunc(string strin)
    {
    strin=strin.Replace("".000"","""");
    return strin;
    }    
    public string Getdateformat(string strin)
    {
           DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime(strin);
            strin = dt2.ToString(""yyyyMMdd"");
            return strin;
    }
public bool LogicalEq(string val1, string val2)
{
	bool ret = false;
	double d1 = 0;
	double d2 = 0;
	if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2))
	{
		ret = d1 == d2;
	}
	else
	{
		ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0;
	}
	return ret;
}


public string StringConcat(string param0)
{
   return param0;
}


public bool IsNumeric(string val)
{
	if (val == null)
	{
		return false;
	}
	double d = 0;
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool IsNumeric(string val, ref double d)
{
	if (val == null)
	{
		return false;
	}
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}


]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects>
  <ExtensionObject Namespace=""http://schemas.microsoft.com/BizTalk/2003/ScriptNS0"" AssemblyName=""GLC.Integration.CargowiseOne.CLASSICBRANDS.Utilites, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0a6f121f7d5d0b26"" ClassName=""GLC.Integration.CargowiseOne.CLASSICBRANDS.Utility.Unitconvertfunction"" />
</ExtensionObjects>";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945";
        
        private const global::GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945 _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945";
                return _TrgSchemas;
            }
        }
    }
}
