namespace GLC.Integration.CargowiseOne.Classic2.Schemas._856.Petco {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856", typeof(global::GLC.Integration.CargowiseOne.Classic2.Schemas._856.X12_00401_856))]
    public sealed class TransformPetcoShipmentToEDI856 : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
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
       
        </ns0:BSN>

      <ns0:HLLoop1>
        <ns0:HL>          
            <HL01>
              <xsl:value-of select=""userCSharp:getcnt()""/>
            </HL01>       
          <HL03>S</HL03>
        </ns0:HL>

        <!--<ns0:TD1>          
            <TD101>
              <xsl:value-of select =""//s0:OuterPacksPackageType/s0:Code/text()""/>              
            </TD101>
          --><!--<xsl:variable name=""varpackedqtytotal"">--><!--
            <xsl:for-each select=""//s0:PackingLineCollection"">
              <xsl:for-each select=""s0:PackingLine"">
                <xsl:value-of select=""userCSharp:setpacklinecnt()""/>
              </xsl:for-each>
            </xsl:for-each>
            
          --><!--</xsl:variable>--><!--
          
          <TD102>
            <xsl:value-of select=""//s0:OuterPacks/text()""/>
          </TD102>

          
          <TD106>G</TD106>
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
          <TD504>M</TD504>
            <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
              <xsl:if test=""s0:AddressType/text()='TransportCompanyDocumentaryAddress'"">                
                      <TD505>
                        <xsl:value-of select=""s0:CompanyName/text()""/>
                      </TD505>               
               
              </xsl:if>
            </xsl:for-each>           
        </ns0:TD5>-->

                   <ns0:REF>
                      <REF01>BM</REF01>
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

        <!--<ns0:FOB>
          <FOB01>CC</FOB01>
          <FOB02>OR</FOB02>          
        </ns0:FOB>-->
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
            <N101>ST</N101>
            
           
                <N102>
                  <xsl:value-of select=""s0:CompanyName/text()""/>
                </N102>

                <N103>ZZ</N103>

                <N104>
                  <xsl:value-of select=""$varn104""/>
                </N104>
            <N106>WH</N106>

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
        <ns0:N1Loop1>
          <ns0:N1>
            <N101>VN</N101>
            <N102>CLASSICBRANDS c/o GDS</N102>
            <N103>ZZ</N103>
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
        <xsl:variable name=""varn1041"">
          <xsl:for-each select=""//s0:CustomizedFieldCollection/s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='N1*ST*04'"">
              <xsl:value-of select=""userCSharp:setlength(s0:Value/text())""/>
            </xsl:if>
          </xsl:for-each>
        </xsl:variable>
        <ns0:N1Loop1>
          <ns0:N1>
            <N101>Z7</N101>
            <N103>92</N103>
            <N104>
              <xsl:value-of select=""$varn1041""/>
            </N104>

          </ns0:N1>
        </ns0:N1Loop1>
       
      </ns0:HLLoop1>

     
     
      <xsl:for-each select =""//s0:PackingLineCollection/s0:PackingLine"">
        <xsl:variable name=""varreferencename"" select=""s0:ReferenceNumber/text()""/>
        <xsl:variable name=""packweight"" select=""s0:Weight/text()""/>

              
        <xsl:variable name=""varpackcntloop"" select=""userCSharp:getcnt()""/>

        <ns0:HLLoop1>
          <ns0:HL>
            <HL01>
              <xsl:value-of select=""$varpackcntloop""/>
            </HL01>
            <HL02>
              <xsl:value-of select=""$ordercnt""/>
            </HL02>

            <HL03>P</HL03>
          </ns0:HL>

          <ns0:MAN>
            <MAN01>GM</MAN01>
            <MAN02>
              <xsl:value-of select=""concat('00',$varreferencename)""/>
            </MAN02>
          </ns0:MAN>

        </ns0:HLLoop1>
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
            <xsl:variable name=""orderconfirm"">
              <xsl:for-each select=""//s0:OrderLineCollection"">
                <xsl:for-each select=""s0:OrderLine"">
                <xsl:variable name=""orderpo"" select=""position()""/>               
                  
                    <xsl:if test=""s0:Product/s0:Code/text()=$varProdcode"">
                     
                        <xsl:value-of select=""$orderpo""/>
                      </xsl:if>
                  
                  </xsl:for-each>
                </xsl:for-each>
             
            
            </xsl:variable>
             
            <xsl:variable name=""varupsccode"">
              <!--<xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderLineCollection/s0:OrderLine[$orderconfirm]/s0:CustomizedFieldCollection/s0:CustomizedField[4]/s0:Value/text()""/>-->

              <xsl:for-each select=""//s0:OrderLineCollection"">
                <xsl:for-each select=""s0:OrderLine"">
                  <xsl:if test=""s0:Product/s0:Code/text()=$varProdcode"">
                    <xsl:for-each select=""s0:CustomizedFieldCollection"">
                      <xsl:for-each select=""s0:CustomizedField"">
                        <xsl:if test=""s0:Key/text()='UPC Case Code'"">
                          <xsl:value-of select=""s0:Value/text()""/>
                        </xsl:if>
                      </xsl:for-each>
                    </xsl:for-each>
                  </xsl:if>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:variable>
      
            <xsl:variable name=""varbuyer"">
              <xsl:for-each select=""//s0:OrderLineCollection"">
                <xsl:for-each select=""s0:OrderLine"">
                  <xsl:if test=""s0:Product/s0:Code/text()=$varProdcode"">
                    <xsl:for-each select=""s0:CustomizedFieldCollection"">
                      <xsl:for-each select=""s0:CustomizedField"">
                        <xsl:if test=""s0:Key/text()='Buyers Catalog#'"">
                          <xsl:value-of select=""s0:Value/text()""/>
                        </xsl:if>
                      </xsl:for-each>
                    </xsl:for-each>
                  </xsl:if>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:variable>
            
            <xsl:variable name=""varconvpacqty"" select =""ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:PackedQuantity/text()))""/>
            <xsl:variable name=""varconvordqty"">
              <xsl:for-each select=""//s0:OrderLineCollection"">
                <xsl:for-each select=""s0:OrderLine"">
                  <xsl:if test=""s0:Product/s0:Code/text()=$varProdcode"">
                    <xsl:value-of select=""ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:OrderedQty/text()))""/>
                  </xsl:if>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:variable>
            <xsl:variable name=""varproddesc"" >
              <xsl:for-each select=""//s0:OrderLineCollection"">
                <xsl:for-each select=""s0:OrderLine"">
                  <xsl:if test=""s0:Product/s0:Code/text()=$varProdcode"">
                    <xsl:value-of select=""s0:Product/s0:Description/text()""/>
                  </xsl:if>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:variable>
            <ns0:HLLoop1>
              <ns0:HL>
                <HL01>
                  <xsl:value-of select=""userCSharp:getcnt()""/>
                </HL01>
                <HL02>
                  <xsl:value-of select=""$varpackcntloop""/>
                </HL02>
                <HL03>I</HL03>
              </ns0:HL>
              <ns0:LIN>
                <LIN01>1</LIN01>
                <LIN02>UP</LIN02>
                <LIN03>
                  <xsl:value-of select=""$varupsccode""/>
                   </LIN03>
                   
                <LIN04>VN</LIN04>
                <LIN05>
                  <xsl:value-of select=""$varProdcode""/>
                </LIN05>               
              </ns0:LIN>

              <ns0:SN1>
                <SN102>
                  <xsl:value-of select=""$varconvpacqty""/>
                </SN102>
                <SN103>EA</SN103>
               </ns0:SN1>

              <ns0:PID>
                <PID01>F</PID01>
                <PID05>
                  <xsl:value-of select=""$varproddesc""/>
                </PID05>
              </ns0:PID>
            </ns0:HLLoop1>

          </xsl:for-each>
        </xsl:for-each>
      </xsl:for-each>
            <ns0:CTT>
              <CTT01>
                <xsl:value-of select=""userCSharp:getfinalhlcnt(userCSharp:getcnt())""/>
              </CTT01>
            </ns0:CTT>
      <xsl:value-of select=""userCSharp:resetcnt()""/>
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
    public int packlinecnt=0;
    
    public void setpacklinecnt()
    {
      packlinecnt=packlinecnt+1;
      }
    
    public string getpacklinecnt()
    {
      return packlinecnt.ToString();
      }
    public int getfinalhlcnt(int val)
    {
      val=val-1;
      return val;
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
