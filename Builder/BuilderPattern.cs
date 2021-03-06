using System; //ssadsdassadsassssasdsadss
using System.Collections.Generic;

namespace Builder
{
  public class MainApp
  {
    public static void Main()
    {
      LaptopBuilder builder;

      LaptopDirector laptopDirector = new LaptopDirector();
      
      builder = new LenovoBuilder();
      laptopDirector.Construct(builder);
      builder.Laptop.Show();
 
      builder = new AsusBuilder();
      laptopDirector.Construct(builder);
      builder.Laptop.Show();
 
      builder = new MSIBuilder();
      laptopDirector.Construct(builder);
      builder.Laptop.Show();
 
      Console.ReadKey();
    }
  }

  class LaptopDirector
  {
    public void Construct(LaptopBuilder laptopBuilder)
    {
      laptopBuilder.BuildKey();
      laptopBuilder.BuildTouchPad();
      laptopBuilder.BuildScreen();
      laptopBuilder.BuildHardware();
    }
  }

  abstract class LaptopBuilder
  {
    protected Laptop laptop;
 
    public Laptop Laptop
    {
      get { return laptop; }
    }
 
    public abstract void BuildKey();
    public abstract void BuildTouchPad();
    public abstract void BuildScreen();
    public abstract void BuildHardware();
  }
 
  class MSIBuilder : LaptopBuilder
  {
    public MSIBuilder()
    {
      laptop = new Laptop("MSI");
    }
 
    public override void BuildKey()
    {
      laptop["key"] = "MSI special design key";
    }
 
    public override void BuildTouchPad()
    {
      laptop["touchpad"] = "MSI special design touchpad";
    }
 
    public override void BuildScreen()
    {
      laptop["screen"] = "MSI special design screen";
    }
 
    public override void BuildHardware()
    {
      laptop["hardware"] = "MSI special design hardware";
    }
  }
 
 
  class LenovoBuilder : LaptopBuilder
  {
    public LenovoBuilder()
    {
      laptop = new Laptop("Lenovo");
    }
 
    public override void BuildKey()
    {
      laptop["key"] = "Lenovo special design key";
    }
 
    public override void BuildTouchPad()
    {
      laptop["touchpad"] = "Lenovo special design touchpad";
    }
 
    public override void BuildScreen()
    {
      laptop["screen"] = "Lenovo special design screen";
    }
 
    public override void BuildHardware()
    {
      laptop["hardware"] = "Lenovo special design hardware";
    }
  }
 
  class AsusBuilder : LaptopBuilder
  {
    public AsusBuilder()
    {
      laptop = new Laptop("Asus");
    }
 
    public override void BuildKey()
    {
      laptop["key"] = "Asus special design key";
    }
 
    public override void BuildTouchPad()
    {
      laptop["touchpad"] = "Asus special design touchpad";
    }
 
    public override void BuildScreen()
    {
      laptop["screen"] = "Asus special design screen";
    }
 
    public override void BuildHardware()
    {
      laptop["hardware"] = "Asus special design hardware";
    }
  }
 
  class Laptop
  {
    private string _laptopType;
    private Dictionary<string,string> _parts = 
      new Dictionary<string,string>();
 
    public Laptop(string laptopType)
    {
      _laptopType = laptopType;
    }
 
    public string this[string key]
    {
      get { return _parts[key]; }
      set { _parts[key] = value; }
    }
 
    public void Show()
    {
      Console.WriteLine("\n---------------------------");
      Console.WriteLine("Laptop Type: {0}", _laptopType);
      Console.WriteLine(" #Key : {0}", _parts["key"]);
      Console.WriteLine(" #Touchpad : {0}", _parts["touchpad"]);
      Console.WriteLine(" #Screen: {0}", _parts["screen"]);
      Console.WriteLine(" #Hardware : {0}", _parts["hardware"]);
    }
  }
}