namespace GLC.Integration.CargowiseOne.Classic2.Schemas._856.HomeDepot {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856", typeof(global::GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856))]
    public sealed class TransformHomeDepotToShipment : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:ns0=""http://schemas.microsoft.com/BizTalk/EDI/X12/2006"" xmlns:s0=""http://www.cargowise.com/Schemas/Universal/2011/11"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"" xmlns:ScriptNS0=""http://schemas.microsoft.com/BizTalk/2003/ScriptNS0"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:UniversalShipment"" />
  </xsl:template>
  <xsl:template match=""/s0:UniversalShipment"">

    <ns0:X12_00401_856>
     
      <xsl:for-each select=""s0:Shipment/s0:PackingLineCollection/s0:PackingLine"">
        <xsl:variable name=""setcnt"" select =""userCSharp:setpackcnt()""/>
      </xsl:for-each>
    <ns0:BSN>
        <BSN01>00</BSN01>
        <BSN02>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderNumber/text()"" />
        </BSN02>
      <xsl:for-each select=""s0:Shipment/s0:DataContext"">
          <xsl:for-each select=""s0:EventType"">
            <xsl:variable name=""var:v2date"" select=""userCSharp:Getdateformat(../s0:TriggerDate/text())"" />
            <BSN03>
              <xsl:value-of select=""$var:v2date""/>
            </BSN03>
          </xsl:for-each>
        </xsl:for-each>
        <xsl:for-each select=""s0:Shipment/s0:DataContext"">
          <xsl:for-each select=""s0:EventType"">
            <xsl:variable name=""var:v1"" select=""userCSharp:LogicalEq(string(s0:Code/text()) , &quot;FIN&quot;)"" />
           <xsl:variable name=""var:v2date"" select=""userCSharp:Gettimeformat(../s0:TriggerDate/text())"" />
            <BSN04>
              <xsl:value-of select=""$var:v2date""/>
            </BSN04>            
          </xsl:for-each>
        </xsl:for-each>
      <BSN05>0001</BSN05>
        </ns0:BSN>

      <ns0:HLLoop1>
        <ns0:HL>          
            <HL01>
              <xsl:value-of select=""userCSharp:getcnt()""/>
            </HL01>       
          <HL03>S</HL03>
        </ns0:HL>

        <ns0:TD1>          
            <TD101>PCS</TD101>
          
            <xsl:for-each select =""//s0:OrderLineCollection/s0:OrderLine"">
              <xsl:variable name=""varProdcode"" select=""s0:Product/s0:Code/text()""/>
                    <xsl:value-of select=""userCSharp:setpackqtycnt(ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:QuantityMet/text())))""/>
                  </xsl:for-each>             
         
          
          <TD102>
            <xsl:value-of select=""userCSharp:getpackqtycnt()""/>
          </TD102>

          
          <TD106>A3</TD106>
          <TD107>
            <xsl:value-of select=""userCSharp:getWeight(s0:Shipment/s0:TotalWeight/text())""/>
          </TD107>
          <TD108>LB</TD108>
        </ns0:TD1>

        <ns0:TD5>
          
          <TD502>2</TD502>          
          <xsl:variable name=""vartd503"">
            <xsl:for-each select=""//s0:CustomizedFieldCollection"">
              <xsl:for-each select=""s0:CustomizedField"">
                <xsl:if test=""s0:Key/text()='SCAC'"">
                  <xsl:value-of select=""s0:Value/text()""/>
                </xsl:if>
              </xsl:for-each>              
            </xsl:for-each>          
          </xsl:variable>            
                <TD503>
                  <xsl:value-of select=""$vartd503""/>
                </TD503>
             
            <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
              <xsl:if test=""s0:AddressType/text()='TransportCompanyDocumentaryAddress'"">                
                      <TD505>
                        <xsl:value-of select=""s0:CompanyName/text()""/>
                      </TD505>               
               
              </xsl:if>
            </xsl:for-each>
          <TD506>CC</TD506>
        </ns0:TD5>

                   <ns0:REF>
                      <REF01>BM</REF01>
                      <REF02>
                        <xsl:value-of select=""s0:Shipment/s0:Order/s0:TransportReference/text()""/>
                          </REF02>
                        </ns0:REF>
        <ns0:REF>
          <REF01>CN</REF01>
          <REF02>
            <xsl:value-of select=""s0:Shipment/s0:Order/s0:TransportReference/text()""/>
          </REF02>
        </ns0:REF>

        <ns0:DTM_2>
          <DTM01>011</DTM01>
          <xsl:for-each select=""s0:Shipment/s0:MilestoneCollection/s0:Milestone"">
            <xsl:if test=""s0:EventCode/text()='FIN'"">
              <DTM02>
                <xsl:value-of select=""userCSharp:Getdateformat(s0:ActualDate/text())""/>
              </DTM02>
            </xsl:if>
          </xsl:for-each>
        </ns0:DTM_2>
        <xsl:variable name=""varn104"">
          <xsl:for-each select=""//s0:CustomizedFieldCollection/s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='N1*ST*04'"">
              <xsl:value-of select=""userCSharp:setlength(s0:Value/text())""/>
            </xsl:if>
          </xsl:for-each>
        </xsl:variable>

        <xsl:variable name=""varn104sf"">
          <xsl:for-each select=""//s0:CustomizedFieldCollection/s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='Vendor Number'"">
              <xsl:value-of select=""s0:Value/text()""/>
            </xsl:if>
          </xsl:for-each>
        </xsl:variable>
        <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
          <xsl:if test=""s0:AddressType/text()='ConsigneeAddress'"">
        <ns0:N1Loop1>
          <ns0:N1>
            <N101>OB</N101>
            
           
                <N102>
                  <xsl:value-of select=""s0:CompanyName/text()""/>
                </N102>

                <N103>91</N103>

                <N104>
                  <xsl:value-of select=""$varn104""/>
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
            <N405>SN</N405>
            <N406>
              <xsl:value-of select=""$varn104""/>
            </N406>
          </ns0:N4>         
        </ns0:N1Loop1>
          </xsl:if>
        </xsl:for-each>
        <ns0:N1Loop1>
          <ns0:N1>
            <N101>SH</N101>
            <N102>CLASSICBRANDS c/o GDS</N102>
            <N103>92</N103>
            <N104>
              <xsl:value-of select=""$varn104sf""></xsl:value-of>
            </N104>
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
      </ns0:HLLoop1>
      <xsl:variable name=""ordercnt"" select=""userCSharp:getcnt()""/>
      <xsl:variable name=""varref04"">
        <xsl:for-each select=""s0:Shipment/s0:MilestoneCollection/s0:Milestone"">
          <xsl:if test=""s0:EventCode/text()='WHE'"">

            <xsl:value-of select=""userCSharp:Getdateformat(s0:ActualDate/text())""/>

          </xsl:if>
        </xsl:for-each>
      </xsl:variable>
      <ns0:HLLoop1>
        <ns0:HL>
          <HL01>
            <xsl:value-of select=""$ordercnt""/>
          </HL01>
          <HL02>1</HL02>

          <HL03>O</HL03>
        </ns0:HL>

        <ns0:PRF>
          <PRF01>
            <xsl:value-of select=""//s0:Order/s0:ClientReference/text()""/>
          </PRF01>
          <PRF04>
            <xsl:value-of select=""$varref04""/>
          </PRF04>

        </ns0:PRF>
        <xsl:variable name=""varweighttd"">
          <xsl:value-of select=""userCSharp:getWeight(s0:Shipment/s0:TotalWeight/text())""/>
        </xsl:variable>

        <ns0:TD1>
          
          <TD106>A3</TD106>
          <TD107>
            <xsl:value-of select=""$varweighttd""/>
          </TD107>
          <TD108>LB</TD108>
        </ns0:TD1>


          <!--<ns0:REF>
            <REF01>IA</REF01>

            <xsl:variable name=""varref02"">
              <xsl:for-each select=""//s0:CustomizedFieldCollection/s0:CustomizedField"">
                <xsl:if test=""s0:Key/text()='Vendor Number'"">
                  <xsl:value-of select=""s0:Value/text()""/>
                </xsl:if>
              </xsl:for-each>
            </xsl:variable>
                <REF02>
                  <xsl:value-of select=""$varref02""></xsl:value-of>
                </REF02>
             
          </ns0:REF>-->
       
      </ns0:HLLoop1>

     
     
      <xsl:for-each select =""//s0:OrderLineCollection/s0:OrderLine"">
        <xsl:variable name=""varreferencename"" select=""s0:ReferenceNumber/text()""/>
        <xsl:variable name=""packweight"" select=""s0:Weight/text()""/>

              
        <!--<xsl:variable name=""varpackcntloop"" select=""userCSharp:getcnt()""/>-->

            <xsl:value-of select=""userCSharp:setpackcount1()""/>
            <xsl:variable name=""varProdcode"" select=""s0:Product/s0:Code/text()""/>             
           
           
             
            <xsl:variable name=""varupsccode"">
                    <xsl:for-each select=""s0:CustomizedFieldCollection"">
                      <xsl:for-each select=""s0:CustomizedField"">
                        <xsl:if test=""s0:Key/text()='UPC Case Code'"">
                          <xsl:value-of select=""s0:Value/text()""/>
                        </xsl:if>
                      </xsl:for-each>
                    </xsl:for-each>
            </xsl:variable>
      
            <xsl:variable name=""varbuyer"">
                    <xsl:for-each select=""s0:CustomizedFieldCollection"">
                      <xsl:for-each select=""s0:CustomizedField"">
                        <xsl:if test=""s0:Key/text()='Buyers Catalog#'"">
                          <xsl:value-of select=""s0:Value/text()""/>
                        </xsl:if>
                      </xsl:for-each>
                    </xsl:for-each>
            </xsl:variable>
            
            <xsl:variable name=""varconvpacqty"" select =""ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:QuantityMet/text()))""/>
        <xsl:value-of select =""userCSharp:sumsn02($varconvpacqty)""/>
            
            <xsl:variable name=""varproddesc"" select=""s0:Product/s0:Description/text()""/>
              
                  
            <ns0:HLLoop1>
              <ns0:HL>
                <HL01>
                  <xsl:value-of select=""userCSharp:getcnt()""/>
                </HL01>
                <HL02>2</HL02>
                <HL03>I</HL03>
              </ns0:HL>
              <ns0:LIN>
                <LIN01>
                  <xsl:value-of select=""userCSharp:getpackcount1()""/>
                </LIN01>
                <LIN02>VP</LIN02>
                <LIN03>
                  <xsl:value-of select=""$varbuyer""/>
                 </LIN03>
                   
                <LIN04>SK</LIN04>
                <LIN05>
                  <xsl:value-of select=""$varProdcode""/>
                </LIN05>
                <LIN06>UP</LIN06>
                <LIN07>
                  <xsl:value-of select=""$varupsccode""/>
                </LIN07>
              </ns0:LIN>

              <ns0:SN1>
                <SN101>
                  <xsl:value-of select=""userCSharp:getpackcount1()""/>
                </SN101>
                <SN102>
                  <xsl:value-of select=""$varconvpacqty""/>
                </SN102>
                <SN103>EA</SN103>
                <!--<SN105>
                  <xsl:value-of select=""$varconvordqty""/>
                </SN105>
                <SN106>EA</SN106>-->

              </ns0:SN1>
              <ns0:SLN>
                <SLN01>
                  <xsl:value-of select=""userCSharp:getpackcount1()""/>
                </SLN01>
                <SLN03>I</SLN03>
                <SLN04>
                  <xsl:value-of select=""$varconvpacqty""/>
                </SLN04>
                <ns0:C001>              
                  <C00101>EA</C00101>
            </ns0:C001>   
              </ns0:SLN>
              <ns0:PO4>
                <PO401>1</PO401>
                  <PO402>
                    <xsl:value-of select=""ScriptNS0:Getpcecount($varProdcode)""/>                  
              </PO402>
              <PO403>EA</PO403>
              </ns0:PO4>
              <ns0:PID>
                <PID01>F</PID01>
                <PID05>
                  <xsl:value-of select=""$varproddesc""/>
                </PID05>
              </ns0:PID>
            </ns0:HLLoop1>

          </xsl:for-each>       
            <ns0:CTT>
              <CTT01>
                <xsl:value-of select=""userCSharp:gethloopcount()""/>
              </CTT01>
              <CTT02>
                <xsl:value-of select=""userCSharp:getsn02val()""/>
              </CTT02>
            </ns0:CTT>
      <xsl:value-of select=""userCSharp:resetcnt()""/>
      <xsl:value-of select=""userCSharp:resetpackcount1()""/>
    </ns0:X12_00401_856>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[
    
    
    public int packcnt=0;
    public string strASNCode="""";
    public int cnt=0;
    public string strnum;
    public int HLcnt=0;
    public int totatcnt=0;
    public string strStore_num;
    public int macycnt=0;
    public string ordercnt="""";
    public int orderlinecnt=0;
    public string strordernum="""";
    public int ordflag=0;
    public decimal packedqty=0.0M;
    public int packcount=0;
    public decimal ctt02val=0.0M;
        
    public void sumsn02(decimal decval)
    {
      ctt02val=ctt02val+decval;
    }
    
    public decimal getsn02val()
    {
      return ctt02val;
    }
   
   public string gethloopcount()
   {
    return cnt.ToString();
   }
    public void setpackcount1()
    {
     packcount=packcount+1;
     }
     
     public string getpackcount1()
     {
      return packcount.ToString();
      }
    
    public void resetpackcount1()
    { 
      packcount=0;
    }
    public string setlength(string strin)
    {
     if(strin.Length <=3)
            {
                strin = ""0"" + strin;
            }
       return strin;
    }
    
    public void setpackqtycnt(decimal packqtyval)
    {
      packedqty=packedqty+packqtyval;
    }
    
    public decimal getpackqtycnt()
    {
      return packedqty;
     }
    public void resetcntpack()
    {
      packedqty=0.0M;
      }
     
    public void setordflag()
    {
      ordflag=ordflag+1;
    }
    
    public string getordflag()
    {
      return ordflag.ToString();
    }
    
    public void resetorderflg()
    { 
    ordflag=0;
    }
    
    public void setorderval1(string strin)
    {
     strordernum=strin;
    }
    
    public string getorderval1()
    {
     return strordernum;
     }
    
    public int getorderlinecnt()
    {
     orderlinecnt=orderlinecnt+1;
     return orderlinecnt;
     }
    
    public string splitLIN5(string strin)
    {
     if(strin != ""-"" || strin != ""--"" || strin != ""---"")
      {
        string[] strval=strin.Split('-');
        strin=strval[0];
      }
      if(strin == ""-"" || strin != ""--"" || strin != ""---"")
        {
           strin="""";
        }
      return strin;
    }
    
    public string splitLIN7(string strin,int a)
    {
      if(strin != ""-"" || strin != ""--"" || strin != ""---"")
      {
        string[] strval=strin.Split('-');
        strin=strval[a];
       }
       
       if(strin == ""-"" || strin == ""--"" || strin == ""---"")
        {
           strin="""";
        }
        return strin;
    }
    public string splitLIN71(string strin)
    {
     if(strin != ""-"" || strin != ""--"" || strin != ""---"")
      {
      string[] strval=strin.Split('-');
      strin=strval[2];
      }
      if(strin == ""-"" || strin != ""--"" || strin != ""---"")
        {
           strin="""";
        }
      return strin;
    }
    public string splitLIN72(string strin)
    {
     if(strin != ""-"" || strin != ""--"" || strin != ""---"")
      {
      string[] strval=strin.Split('-');
      strin=strval[3];
      }
       if(strin == ""-"" || strin != ""--"" || strin != ""---"")
        {
          strin="""";
        }
      return strin;
    }
    
    public string getWeight(double weightin)
    {
      weightin=weightin*2.205;
      return weightin.ToString();
    }
    
    public string getordercnt()
    {
     return ordercnt;
    }
    
    public void setorderflag(string strin)
    {
      ordercnt=strin;
    }
    
    public string setMacycnt()
    {
      macycnt=macycnt+1;
      return macycnt.ToString();
    }
    
    public string getmactotalcnt()
    {
    return macycnt.ToString();
    }
    
    public void setpackcnt()
    {
      packcnt=packcnt+1;
    }
    
    public string getpackcnt()
    {
      return packcnt.ToString();
    }
    public void setASNCODE(string strin)
    {
      strASNCode=strin;
    }
    public string getASNCODE()
    {
      return strASNCode;
    }
    
    public string getstorenum(string strin)
    { 
            string strdata = strin;
           
            string[] inpt1 = strdata.Split(':');
            string strnum = inpt1[1].Replace("" "","""");
            return strnum;
    }
    
    public void appendstrnum(string strin)
    {
      strnum=strin;
    }
    
    public int gettotalcnt()
    {
    return totatcnt;
    }
    
    public string getstrnum()
    {
    return strnum;
      }
    public int getcnt()
    {
      cnt=cnt+1;
      totatcnt=cnt;
      return cnt;
    }
    
    public int HLgetcnt()
    {
      HLcnt=HLcnt+1;
      return HLcnt;
    }
    
    public string strremove(string strin)
    
    {
     strin=strin.Replace("".000"", """");
     return strin;
    }
    public void resetcnt()
    {
    totatcnt=0;
      cnt=0;
      HLcnt=0;
      packcnt=0;
      macycnt=0;
      strnum="""";
      ordercnt="""";
      orderlinecnt=0;
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
    public string ASNGetdateformat(string strin)
        {
            DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime(strin);
            dt2=dt2.AddDays(1);
            strin = dt2.ToString(""yyyyMMdd"");
            return strin;
        }
    
    public string Gettimeformat(string strin)
    {
           DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime(strin);
            strin = dt2.ToString(""HHmmss"");
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
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856";
        
        private const global::GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856 _trgSchemaTypeReference0 = null;
        
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
                _TrgSchemas[0] = @"GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856";
                return _TrgSchemas;
            }
        }
    }
}
