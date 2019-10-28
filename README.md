# softaware.Xaml.Converters

This Library contains various common implementations of the ```IValueConverter``` interface for WPF and UWP apps:

* **BooleanConverter:** Converts ```true```/```false``` to the values specified by the properties ```TrueValue``` and ```FalseValue```. A ```BooleanToVisibilityConverter``` could be implemented like this:
```Xaml
<sxc:BooleanConverter x:Key="BooleanToVisibilityConverter" TrueValue="Visible" FalseValue="Collapsed"/>
```
* **BooleanInverter:** Converts  ```true``` to ```false``` and vice versa.
* **BooleanToVisibilityConverter:** Converts ```true```/```false``` to ```Visible```/```Collapsed``` (or ```Hidden```).
* **EqualsConverter:** Returns ```true``` when ```value``` and ```parameter``` are equal (according to the ```Equals``` method). In WPF the converter can also be used as ```IMultiValueConverter``` to compare two values bound via ```MultiBinding```.
* **NullConverter:** Returns ```true``` when ```value``` is ```null```, otherwise ```false```. Empty strings can be treated as null by settings the ```TreatEmptyStringAsNull``` property to ```true```.
* **StringFormatConverter:** Formats ```value``` using ```parameter``` as format string. The formatting of empty strings can be controlled with the ```FormatEmptyString``` property.
* **EmptyConverter:** Checks if ```value``` is an empty ```IEnumerable```. The ```TreatNullAsEmpty``` property can be set to ```true``` or ```false```.
* **ContainsConverter:** Checks if ```IEnumerable``` passed as ```value``` contains ```parameter```. In WPF the converter can also be used as ```IMultiValueConverter``` to compare two bound values.
* **MappingConverter:** This converter enables the definition of the mapping directly in XAML  (which is especially useful for enums):
```Xaml
<sxc:MappingConverter x:Key="StateConverter">
  <sxc:Mapping From="{x:Static common:State.Created}" To="Waiting..."/>
  <sxc:Mapping From="{x:Static common:State.InProgress}" To="In progress..."/>
  <sxc:Mapping From="{x:Static common:State.Finished}" To="Finished"/>
</sxc:MappingConverter>
```
* **ConverterChain:** This converter can be used to execute multiple converters in row.  A ```BooleanToVisibilityConverter``` could be implemented like this:
```Xaml
<sxc:ConverterChain x:Key="NullToVisibilityConverter">
  <sxc:NullConverter/>
  <sxc:BooleanInverter/>
  <sxc:BooleanToVisibilityConverter/>
</vpc:ConverterChain>
```
