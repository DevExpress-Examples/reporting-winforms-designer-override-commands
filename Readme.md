<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128604989/13.2.12%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4354)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/CustomSavingEUD/Form1.cs) (VB: [Form1.vb](./VB/CustomSavingEUD/Form1.vb))**
<!-- default file list end -->
# WinForms End-User Designer - How to override commands (implement custom saving)


<p>This example demonstrates how to override and customize saving in the <a href="http://documentation.devexpress.com/#XtraReports/CustomDocument1198"><u>End-User Designer</u></a>. This can be useful, for example, if all the reports in a project should be stored in a database, and are retrieved from the database via a stream, and all of this should be done automatically, without forcing an end-user to do anything but click the <strong>Save</strong> (or <strong>Save As</strong>) toolbar button.</p>
<p>For a more complex approach on saving reports in an End-User Designer, see <a href="https://www.devexpress.com/Support/Center/p/E2704">Report Storage for the End-User Report Designer</a>.</p>
<p>In this example, a report will also be automatically saved using the custom saving procedure when an end-user closes the Report Designer.</p>
<p>To implement this task, handle the <strong>ReportCommand.SaveFile</strong> and <strong>ReportCommand.SaveFileAs</strong> commands. Note that to prevent the standard saving procedure from being called, you just need to enable the handled property.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-designer-override-commands&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-designer-override-commands&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
