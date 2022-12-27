<Query Kind="Program">
  <NuGetReference>ClosedXML</NuGetReference>
  <Namespace>ClosedXML</Namespace>
  <Namespace>ClosedXML.Excel</Namespace>
</Query>

void Main()
{
	var wb = new ClosedXML.Excel.XLWorkbook(Path.GetDirectoryName(Util.CurrentQueryPath) + "/iceCreams.xlsx");
	
	var ws = wb.Worksheets.First();
	
	var lsIceCream = new List<IceCream>();
	
	for (int i = 2; i <= ws.RowsUsed().Count(); i++)
	{
		IceCream ic = new IceCream();
		
		ic.Name = ws.Cell(i,1).Value.ToString();
		int.TryParse(ws.Cell(i,2).Value.ToString(),out int qty);
		ic.Qty = qty;
		int.TryParse(ws.Cell(i,3).Value.ToString(), out int id);
		ic.ID = id;
		
		lsIceCream.Add(ic);
	}
	
	lsIceCream.Dump();
	
	
}

// Define other methods and classes here
public class IceCream
{
	public int ID { get; set; }
	public string Name { get; set; }
	public int Qty { get; set; }
}