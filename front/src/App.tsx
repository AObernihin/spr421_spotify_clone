
import { Route, Routes } from 'react-router'
import './App.css'
import Navbar from './components/navbar/Navbar'
import DefaultLayout from './components/layouts/DefaultLayout'
import MainPage from './pages/mainPages/MainPage'
import LoginPage from './pages/auth/LoginPage'
import RegistryPage from './pages/auth/RegistryPage'
import AddTrackPage from './pages/dev/AddTrack'

function App() {
  

  return (
    <>
      <Routes>
        <Route path="/" element={<DefaultLayout/>}>
          <Route index element={<MainPage/>} />
          <Route path="login" element={<LoginPage/>} />
          <Route path="signup" element={<RegistryPage/>} />
          <Route path="Track" element={<AddTrackPage/>} />
        </Route>
      </Routes>
    </>
  )
}

export default App
