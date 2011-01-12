<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dialogs.ascx.cs" Inherits="ECommerce2010.CMS.UserControl.Dialogs" %>
<!-- dialogs -->
		<div id="dialog" title="Basic Dialog">
			<p>This is an animated dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
		</div>
		<div id="dialog-modal" title="Basic Modal Dialog">
			<p>Adding the modal overlay screen makes the dialog look more prominent because it dims out the page content.</p>
		</div>
		<div id="dialog-message" title="Download Complete">
			<p><span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>Your files have downloaded successfully into the My Downloads folder.</p>
			<p>Currently using <b>36% of your storage space</b>.</p>
		</div>
		<div id="dialog-confirm" title="Empty the Recycle Bin?">
			<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>These items will be permanently deleted and cannot be recovered. Are you sure?</p>
		</div>
		<div id="dialog-form" title="Create new user">
			<p>All form fields are required.</p>
			<form action="" method="post">
			<div class="form">
				<div class="fields">
					<div class="field field-first">
						<div class="label">
							<label for="input">Name:</label>
						</div>
						<div class="input">
							<input type="text" id="user-name" name="user.name" />
						</div>
					</div>
					<div class="field">
						<div class="label">
							<label for="input">Email:</label>
						</div>
						<div class="input">
							<input type="text" id="user-email" name="user.email" />
						</div>
					</div>
					<div class="field">
						<div class="label">
							<label for="input">Password:</label>
						</div>
						<div class="input">
							<input type="text" id="user-password" name="user.password" />
						</div>
					</div>
				</div>
			</div>
			</form>
		</div>
		<!-- end dialogs -->