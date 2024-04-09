# Azure Storage Ranged Responses Fixer

This project aims to address the issue of browsers being unable to seek audio files stored on Azure Storage due to problems with ranged responses. By setting the `DefaultServiceVersion` property to '2013-08-15' for Azure Storage, this project provides a simple fix to ensure seamless seeking of audio files.

## Problem

When serving audio files from Azure Storage, certain browsers encounter difficulties seeking within these files due to issues with ranged responses. This can result in a poor user experience for applications reliant on audio playback, such as media players or streaming services.

## Solution Overview

This project proposes setting the `DefaultServiceVersion` property of Azure Storage to '2013-08-15'. By doing so, it aims to mitigate the problems associated with ranged responses, thus enabling smooth seeking within audio files stored on Azure Storage.

## How It Works

The `DefaultServiceVersion` property determines the version of the Azure Storage Blob service used when creating a storage account. By setting it to '2013-08-15', we ensure compatibility with browsers that may struggle with ranged responses in newer versions.

## Getting Started

To use this fix in your Azure Storage setup, follow these steps:

1. **Clone or download this repository**:
```
git clone https://github.com/BrettSheleski/FixAzureStorageRangedResponses.git
```

2. **Modify your Azure Storage configuration**:
Set the `StorageAccountName` and `StorageAccountKey` constants to the values found in Azure Portal for your storage account.

3. **Run the GetDefaultStorageVersion Unit Test**:
This should fail initially signifying it needs to be updated.

4. **Run the SetDefaultStorageVersion20130815 Unit Test**:
This will set the `DefaultServiceVersion` to '2013-08-15' .

5. **Run the GetDefaultStorageVersion Unit Test Again**:
This should now succeed.

## Contribution Guidelines

Contributions to this project are welcome! If you encounter any issues or have suggestions for improvement, feel free to open an issue or submit a pull request.

## Acknowledgments

See https://stackoverflow.com/questions/17408927/do-http-range-headers-work-with-azure-blob-storage-shared-access-signatures which helped me what the problem is and how to resolve it.
