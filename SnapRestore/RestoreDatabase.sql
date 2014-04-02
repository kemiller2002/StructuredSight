USE Master --Any db but the one you are restoring will do.  
--Being in the same db will lock it and prevent the restore.
RESTORE DATABASE Example FROM Database_Snapshot = 'snap_example'