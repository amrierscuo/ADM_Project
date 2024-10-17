Get-ChildItem -Directory | ForEach-Object {
    $fileCount = (Get-ChildItem -Recurse -File $_.FullName).Count
    if ($fileCount -le 10) {
        git add $_.FullName
    }
}
git commit -m "Add only directories with up to 10 files"
git push origin master
