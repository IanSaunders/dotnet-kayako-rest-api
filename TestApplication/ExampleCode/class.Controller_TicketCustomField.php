<?php
/**
 * =======================================
 * ###################################
 * SWIFT Framework
 *
 * @package	SWIFT
 * @author	Kayako Infotech Ltd.
 * @copyright	Copyright (c) 2001-2009, Kayako Infotech Ltd.
 * @license	http://www.kayako.com/license
 * @link		http://www.kayako.com
 * @filesource
 * ###################################
 * =======================================
 */

/**
 * The TicketCustomField API Controller
 *
 * @author Varun Shoor
 */
class Controller_TicketCustomField extends Controller_api implements SWIFT_REST_Interface
{
	/**
	 * Constructor
	 *
	 * @author Varun Shoor
	 * @return bool "true" on Success, "false" otherwise
	 */
	public function __construct()
	{
		parent::__construct();

		$this->Load->Library('XML:XML');

		$this->Load->Library('Attachment:Attachment', false, false);
		$this->Load->Library('Attachment:AttachmentStore', false, false);
		$this->Load->Library('Attachment:AttachmentStoreString', false, false);
		$this->Load->Library('Attachment:AttachmentStoreFile', false, false);
		$this->Load->Library('Rules:Rules', false, false);
		$this->Load->Library('SearchStore:SearchStore', false, false);
		$this->Load->Library('Search:TicketSearchManager', false, false);
		$this->Load->Library('SearchEngine:SearchEngine', false, false);

		$this->Load->Library('Ticket:Ticket', false, false);
		$this->Load->Library('Ticket:TicketPost', false, false);
		$this->Load->Library('Ticket:TicketLinkedTable', false, false);

		$this->Load->Library('Search:TicketSearch', false, false);

		$this->Load->Library('Recipient:TicketRecipient', false, false);

		$this->Load->Library('View:TicketView', false, false);
		$this->Load->Library('View:TicketViewRenderer', false, false);
		$this->Load->Library('View:TicketViewPropertyManager', false, false);

		$this->Load->Library('Watcher:TicketWatcher', false, false);

		$this->Load->Library('Link:TicketLinkType', false, false);
		$this->Load->Library('Link:TicketLinkChain', false, false);

		$this->Load->Library('UserInterface:UserInterfaceTab', false, false);
		$this->Load->Library('UserInterface:UserInterfaceGrid', false, false);
		$this->Load->Library('Department:Department', false, false);

		$this->Load->Library('Staff:Staff', false, false);
		$this->Load->Library('Staff:StaffGroupLink', false, false);

		$this->Load->Library('FileManager:FileManager', false, false);

		$this->Load->Library('User:User', false, false);
		$this->Load->Library('User:UserProfileImage', false, false);

		$this->Load->Library('Flag:TicketFlag', false, false);

		$this->Load->Library('Tag:Tag', false, false);
		$this->Load->Library('Tag:TagLink', false, false);

		$this->Load->Library('Benchmark:Benchmark', false, false);
		$this->Load->Library('Benchmark:BenchmarkResult', false, false);
		$this->Load->Library('Benchmark:BenchmarkRenderer', false, false);

		$this->Load->Library('Lock:TicketLock', false, false);

		$this->Load->Library('TimeTrack:TicketTimeTrack', false, false);
		$this->Load->Library('TimeTrack:TicketTimeTrackNote', false, false);

		$this->Load->Library('Note:TicketNoteManager', false, false);
		$this->Load->Library('Note:TicketNote', false, false);
		$this->Load->Library('Note:TicketPostNote', false, false);

		$this->Load->Library('User:User', false, false);
		$this->Load->Library('User:UserOrganization', false, false);
		$this->Load->Library('User:UserNoteManager', false, false);
		$this->Load->Library('User:UserNote', false, false);
		$this->Load->Library('User:UserOrganizationNote', false, false);

		$this->Load->Library('Filter:TicketFilter', false, false);
		$this->Load->Library('Filter:TicketFilterField', false, false);

		$this->Load->Library('Mobile:TicketMobileManager', false, false);

		$this->Load->Library('CustomField:CustomField', false, false);
		$this->Load->Library('CustomField:CustomFieldManager', false, false);
		$this->Load->Library('CustomField:CustomFieldGroup', false, false);

		$this->Language->Load('staff_ticketsmain');
		$this->Language->Load('staff_ticketsmanage');
		$this->Language->Load('staff_ticketssearch');

		SWIFT_Ticket::LoadLanguageTable();

		return true;
	}

	/**
	 * Destructor
	 *
	 * @author Varun Shoor
	 * @return bool "true" on Success, "false" otherwise
	 */
	public function __destruct()
	{
		parent::__destruct();

		return true;
	}

	/**
	 * GetList
	 *
	 * @author Varun Shoor
	 * @return bool "true" on Success, "false" otherwise
	 * @throws SWIFT_Exception If the Class is not Loaded
	 */
	public function GetList()
	{
		if (!$this->GetIsClassLoaded())
		{
			throw new SWIFT_Exception(SWIFT_CLASSNOTLOADED);

			return false;
		}

		$this->RESTServer->DispatchStatus(SWIFT_RESTServer::HTTP_BADREQUEST, 'Not Implemented, Call GET /Tickets/TicketCustomField/$ticketid$ instead.');

		return false;
	}


        /**
         * Update a Custom Ticket ID
         *
         * Example Output: http://wiki.kayako.com/display/DEV/REST+-+Ticket
         *
         * @author Varun Shoor
         * @param int $_ticketID The Ticket ID
         * @return bool "true" on Success, "false" otherwise
         * @throws SWIFT_Exception If the Class is not Loaded
         */
        public function Put($_ticketID)
        {
             if (!$this->GetIsClassLoaded())
             {
                   throw new SWIFT_Exception(SWIFT_CLASSNOTLOADED);
                   return false;
             }

              if (!isset($_POST['custom_field_value']) || empty($_POST['custom_field_value']) || trim($_POST['custom_field_value']) == '') {
                      $this->RESTServer->DispatchStatus(SWIFT_RESTServer::HTTP_BADREQUEST, 'No Custom Field Value Specified');

                      return false;
              }

              $custom_field_value = $_POST['custom_field_value'];


$sql_update_field = <<< UPDATE_FIELD
 UPDATE swcustomfieldvalues 
 SET
   fieldvalue = '$custom_field_value'
 WHERE
    customfieldid = 1 AND typeid = $_ticketID;
UPDATE_FIELD;

//echo $sql_update_field;  
 
            $this->Database->Query( $sql_update_field);

            return $this->Get( $_ticketID  );  
        }
         
        public function Delete($_ticketID)
        {
             if (!$this->GetIsClassLoaded())
             {
                   throw new SWIFT_Exception(SWIFT_CLASSNOTLOADED);
                   return false;
             }

$sql_remove_link = <<< REMOVE_LINK
 DELETE FROM swcustomfieldlinks
 WHERE
   grouptype = 3 AND linktypeid = '$_ticketID' AND customfieldgroupid = 1;
REMOVE_LINK;

$sql_remove_field = <<< REMOVE_FIELD
 DELETE FROM swcustomfieldvalues
 WHERE
   typeid = '$_ticketID';
REMOVE_FIELD;


          $this->Database->Query( $sql_remove_link  );
          $this->Database->Query( $sql_remove_field );

          return true;
        }


        public function Post()
        {
             if (!$this->GetIsClassLoaded())
             {
                   throw new SWIFT_Exception(SWIFT_CLASSNOTLOADED);
                   return false;
             }

              if (!isset($_POST['ticketid']) || empty($_POST['ticketid']) || trim($_POST['ticketid']) == '') {
                      $this->RESTServer->DispatchStatus(SWIFT_RESTServer::HTTP_BADREQUEST, 'No Ticket ID Specified');
                      return false;
              }

              if (!isset($_POST['custom_field_value']) || empty($_POST['custom_field_value']) || trim($_POST['custom_field_value']) == '') {
                      $this->RESTServer->DispatchStatus(SWIFT_RESTServer::HTTP_BADREQUEST, 'No Custom Field Value Specified');

                      return false;
              }

              $ticket_id = $_POST['ticketid'];
              $custom_field_value = $_POST['custom_field_value'];
              $u_hash = uniqid();

$sql_add_link = <<< ADD_LINK
 INSERT INTO swcustomfieldlinks
 (
   grouptype,
   linktypeid,
   customfieldgroupid
 )
 VALUES
 (
   3,
   $ticket_id,
   1
 );
ADD_LINK;

$sql_add_field = <<< ADD_FIELD
 INSERT INTO swcustomfieldvalues
 (
   customfieldid,
   typeid,
   fieldvalue,
   uniquehash
 )
 VALUES
 (
    1,
    $ticket_id,
   '$custom_field_value',
   '$u_hash'     
 );

ADD_FIELD;

          $this->Database->Query( $sql_add_link  );
          $this->Database->Query( $sql_add_field );
          
          return $this->Get( $ticket_id  );
        }

	/**
	 * Get a list of custom fields for the given ticket
	 *
	 * Example Output: http://wiki.kayako.com/display/DEV/REST+-+TicketCustomField
	 *
	 * @author Varun Shoor
	 * @param int $_ticketID The Ticket ID
	 * @return bool "true" on Success, "false" otherwise
	 * @throws SWIFT_Exception If the Class is not Loaded
	 */
	public function Get($_ticketID)
	{
		if (!$this->GetIsClassLoaded())
		{
			throw new SWIFT_Exception(SWIFT_CLASSNOTLOADED);

			return false;
		}

		$_SWIFT_TicketObject = SWIFT_Ticket::GetObjectOnID($_ticketID);
		if (!$_SWIFT_TicketObject instanceof SWIFT_Ticket || !$_SWIFT_TicketObject->GetIsClassLoaded()) {
			$this->RESTServer->DispatchStatus(SWIFT_RESTServer::HTTP_NOTFOUND, 'Ticket not Found');

			return false;
		}

		$_customFieldCache = $this->Cache->Get('customfieldcache');
		$_customFieldIDCache = $this->Cache->Get('customfieldidcache');
		$_customFieldMapCache = $this->Cache->Get('customfieldmapcache');
		$_customFieldOptionCache = $this->Cache->Get('customfieldoptioncache');

		$_customFieldIDList = array();
		if (isset($_customFieldIDCache['ticketcustomfieldidlist'])) {
			$_customFieldIDList = $_customFieldIDCache['ticketcustomfieldidlist'];
		}

		$_customFieldGroupTypeList = array(SWIFT_CustomFieldGroup::GROUP_STAFFTICKET, SWIFT_CustomFieldGroup::GROUP_STAFFUSERTICKET, SWIFT_CustomFieldGroup::GROUP_USERTICKET);

		$_rawCustomFieldValueContainer = $_customFieldValueContainer = $_customArguments = array();

		$this->Database->Query("SELECT * FROM " . TABLE_PREFIX . "customfieldvalues WHERE customfieldid IN (" . BuildIN($_customFieldIDList) . ") AND typeid = '" . intval($_ticketID) . "'");
		while ($this->Database->NextRecord())
		{
			if (!isset($_customFieldMapCache[$this->Database->Record['customfieldid']])) {
				continue;
			}

			$_rawCustomFieldValueContainer[$this->Database->Record['customfieldid']] = $this->Database->Record;

			// If we already have data set from POST request then we continue as is
			if (isset($_customFieldValueContainer[$this->Database->Record['customfieldid']])) {
				continue;
			}

			$_fieldValue = '';
			if ($this->Database->Record['isencrypted'] == '1')
			{
				$_fieldValue = SWIFT_CustomFieldManager::Decrypt($this->Database->Record['fieldvalue']);
			} else {
				$_fieldValue = $this->Database->Record['fieldvalue'];
			}

			if ($this->Database->Record['isserialized'] == '1')
			{
				$_fieldValue = mb_unserialize($_fieldValue);
			}

			$_customField = $_customFieldMapCache[$this->Database->Record['customfieldid']];

			if (_is_array($_fieldValue) && ($_customField['fieldtype'] == SWIFT_CustomField::TYPE_CHECKBOX || $_customField['fieldtype'] == SWIFT_CustomField::TYPE_SELECTMULTIPLE)) {
				foreach ($_fieldValue as $_key => $_val) {
					if (isset($_customFieldOptionCache[$_val])) {
						$_fieldValue[$_key] = $_customFieldOptionCache[$_val];
					}
				}
			} else if ($_customField['fieldtype'] == SWIFT_CustomField::TYPE_RADIO || $_customField['fieldtype'] == SWIFT_CustomField::TYPE_SELECT) {
				if (isset($_customFieldOptionCache[$_fieldValue])) {
					$_fieldValue = $_customFieldOptionCache[$_fieldValue];
				}
			} else if ($_customField['fieldtype'] == SWIFT_CustomField::TYPE_SELECTLINKED) {
				$_fieldValueInterim = '';
				if (isset($_customFieldOptionCache[$_fieldValue[0]])) {
					$_fieldValueInterim = $_customFieldOptionCache[$_fieldValue[0]];

					foreach ($_fieldValue[1] as $_key => $_val) {
						if (isset($_customFieldOptionCache[$_val])) {
							$_fieldValueInterim .= ' &gt; ' . $_customFieldOptionCache[$_val];
							break;
						}
					}
				}

				$_fieldValue = $_fieldValueInterim;
			} else if ($_customField['fieldtype'] == SWIFT_CustomField::TYPE_FILE) {
				$_fieldValueInterim = '';

				try {
					$_SWIFT_FileManagerObject = new SWIFT_FileManager($_fieldValue);

					$_fieldValueInterim = base64_encode($_SWIFT_FileManagerObject->GetBase64());
					$_customArguments[$_customField['customfieldid']]['filename'] = $_SWIFT_FileManagerObject->GetProperty('originalfilename');
				} catch (SWIFT_Exception $_SWIFT_ExceptionObject) {


				}

				$_fieldValue = $_fieldValueInterim;
			}

			$_customFieldValueContainer[$this->Database->Record['customfieldid']] = $_fieldValue;
		}

		$this->XML->AddParentTag('customfields');

		if (_is_array($_customFieldCache)) {
			foreach ($_customFieldCache as $_groupType => $_customFieldGroupContainer) {
				if (!in_array($_groupType, $_customFieldGroupTypeList)) {
					continue;
				}

				foreach ($_customFieldGroupContainer as $_customFieldGroupID => $_customFieldGroup) {
					$this->XML->AddParentTag('group', array('id' => $_customFieldGroupID, 'title' => $_customFieldGroup['title']));

					foreach ($_customFieldGroup['_fields'] as $_customFieldID => $_customField) {
						$_customFieldValue = '';
						if (isset($_customFieldValueContainer[$_customFieldID]) && _is_array($_customFieldValueContainer[$_customFieldID])) {
							$_customFieldValue = implode(', ', $_customFieldValueContainer[$_customFieldID]);
						} else {
							if( array_key_exists( $_customFieldID, $_customFieldValueContainer  )  )
                                                        {
                                                          $_customFieldValue = $_customFieldValueContainer[$_customFieldID];
                                                        }
                                                        else
                                                        {
                                                          $_customFieldValue = '';
                                                        }
						}

						$_fieldArguments = array('id' => $_customFieldID, 'title' => $_customField['title'], 'type' => $_customField['fieldtype']);

						if (isset($_customArguments[$_customFieldID])) {
							$_fieldArguments = array_merge($_fieldArguments, $_customArguments[$_customFieldID]);
						}

						$this->XML->AddTag('field', $_customFieldValue, $_fieldArguments);
					}

					$this->XML->EndParentTag('group');
				}

			}
		}

		$this->XML->EndParentTag('customfields');

		$this->XML->EchoXML();

		return true;
	}
}
?>
