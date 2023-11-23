# AlphaMissenseViewer

AlphaMissenseViewer is designed to allow the rapid searching of the AlphaMissense_hg19.tsv or AlphaMissense_hg38.tsv files for the data for specific mutations or are possible variants in a gene or transcript. 

The data was produced using the AlphaMissense algorithm ([Github](https://github.com/google-deepmind/alphamissense)) and decribed in the [Science paper](https://www.science.org/doi/10.1126/science.adg7492).

## Before you start

The search function works by performing a [binary search](https://en.wikipedia.org/wiki/Binary_search_algorithm) on the data file. To do this, the file must be decompressed using a program like 7zip or Windows 11's decompression function. To search for possible variants in a gene or transcrip, the file most first be indexed using the program's Index function.

## Downloading the data files

Currently the AlphaMissense data files are [here](https://console.cloud.google.com/storage/browser/dm_alphamissense;tab=objects?prefix=&forceOnObjectsSortingFiltering=false&pli=1) and can be downloaded by either clicking on the tray icon on the rigth of the landing page or by selecting the file and selecting the 'Download' button on the file specific page. Once downloaded extract the file using a program like 7zip or the inbuilt decomression function in newer Windows OS's.

## Selecting the (decompressed) data file

When started the search buttons are disabled (figure 1), to enable them press the ``Select`` button in the top right and select a data file. 

![Figure 1](images/figure1.jpg)
