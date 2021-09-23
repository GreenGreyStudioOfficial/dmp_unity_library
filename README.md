# com.greengreysoftworks.dmpanalytics
Unity Package for com.greengreysoftworks.dmpanalytics

# Version

This package includes 

Version: 0.0.2

# Add to your project with git url (2019.3+)

Open the manifest.json for your project and add the following entry for create reference to new scoped registry

```json
  "scopedRegistries": [
    {
      "name": "GreenGray",
      "url": "http://80.78.245.35:4873/",
      "scopes": [
        "com.greengreysoftworks"
      ]
    }],
  "dependencies": {
    ...
```

and following entry to your list of dependencies to add package dependency

```json
"com.greengreysoftworks.dmpanalytics": "%CURRENT_PACKAGE_VERSION%",
```

Example:
```json
  "scopedRegistries": [
    {
        "name": "GreenGray",
        "url": "http://80.78.245.35:4873/",
        "scopes": [
        "com.greengreysoftworks"
    ]
    }],
    "dependencies": {
        "com.greengreysoftworks.dmpanalytics": "0.0.2",
        "com.unity.ads": "2.0.8",
        "com.unity.analytics": "3.2.2",
        "com.unity.collab-proxy": "1.2.15",
        ...
    }
 }
```

# Using the package

TODO: Using package
