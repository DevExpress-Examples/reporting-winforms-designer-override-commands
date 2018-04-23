# WinForms End-User Designer - How to override commands (implement custom saving)


<p>This example demonstrates how to override and customize saving in the <a href="http://documentation.devexpress.com/#XtraReports/CustomDocument1198"><u>End-User Designer</u></a>. This can be useful, for example, if all the reports in a project should be stored in a database, and are retrieved from the database via a stream, and all of this should be done automatically, without forcing an end-user to do anything but click the <strong>Save</strong> (or <strong>Save As</strong>) toolbar button.</p>
<p>For a more complex approach on saving reports in an End-User Designer, see <a href="https://www.devexpress.com/Support/Center/p/E2704">Report Storage for the End-User Report Designer</a>.</p>
<p>In this example, a report will also be automatically saved using the custom saving procedure when an end-user closes the Report Designer.</p>
<p>To implement this task, handle the <strong>ReportCommand.SaveFile</strong> and <strong>ReportCommand.SaveFileAs</strong> commands. Note that to prevent the standard saving procedure from being called, you just need to enable the handled property.</p>

<br/>


