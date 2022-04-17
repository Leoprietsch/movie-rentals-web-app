# Matrix Discord Chat

The Matrix Chat is a Discord like application with the Matrix theme. I developed this little project to create something with Reactjs and Nextjs using TypeScript.
I have built a real-time chat using Supabase BaaS, which is a open source alternative for Google's Firebase.

## About the "ts-ignore" comments in the code

You will probably find a lot of comments like this, because the Skynex UI components were missing some of the style types in the StyleSheet interface.
Every @ts-ignore in the code will turn into a Issue for the Skynex UI and hopefully a Pull Request to resolve these missing types at the Skynex UI components once the training week is over.

## Login Screen

![Login Screenshot](https://i.imgur.com/9WHbcAe.png)

## Matrix Chat Screen

![Matrix Chat Screenshot](https://i.imgur.com/tpVPb6U.png)

To run this application, you will need `node` and `yarn` installed.

Installation:

```sh
yarn install
```

To run the App:

```sh
yarn run dev
```

If you wish to run the application using your own Supabase as your BaaS, your Messages table must look like this:
![Messages table model](https://i.imgur.com/PiDQM8K.png)
