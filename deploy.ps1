param([string]$projectName, [string]$location)

az group delete --resource-group $projectName --yes 
az group create --resource-group $projectName --location $location
az deployment group create --resource-group $projectName --template-file deploy-stf.json --parameters projectName=$projectName adminUsername=aleksbol adminPublicKey="ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAACAQCsGHFYhLieeRSlgreDQU9eyl8feMMa/7HQosSyGqKuiXjQ4ngzc9peKqYI8AV4gpWBysOlovaj9DfyHHGlm/f6bl+I881o3E0iU+xYpdPIQXUAkkRCMCdwXEIFY3hnMykbCGHTU2+XIglNEfT+kDhDEPYP4bMlBTKY03LIOYo3Ur71oUiIV56U7fmB9EygVDSk3n05rm23qd/ek5BLXbu6wY/f0RxSdwlf07xujkMiQyqR2Iug8sWGjiMkgH6RIxSQRI0u+uLwxeerH2JT37k4TfdCeXmRi3uPDa+xpZS5/A9DCmPFbAS6uSHrlMxZ9LiR/WKZdu7aOh/sY0hV/tDbdQkVXDJt2Erht1Qs2upKsLRLfDO+/9Wtmx2Uew1R/hqbaavZl3j0GmqN+vxQ6aEtrWbq2rbzxOmPM7aLOjnoU/j2IZZe7opjETrVsWVilvHuo0/dtqfI1QOQ6HpvD6f/Oa1i2A/QXSETdUb03trhB3Ylig5LOIxxrcdFxlXu3ZhgsAFGN7Tk5Q5ZBqn9JjPtneDr/6yXBDXWtf0ZeqtjF2L2k+AFZ39j3JMxGtZWw0I8c2yslNVIf1o+tW3ya9aeC3u8BoHcpThrVVX6WBHha+szcExH/dQvsvcSGnDmLOzIVUeGInLTXrLAwtYZBrPDTmbKrBBPypE7joLbt+J31w== redmond\aleksbol@LAPTOP-GA4VCRGE"