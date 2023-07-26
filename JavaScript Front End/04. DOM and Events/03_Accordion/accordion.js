function toggle()
{
    let btn = document.getElementsByClassName('button')[0];

    if (btn.textContent == 'More')
    {
        btn.textContent = 'Less';
        document.getElementById('extra').style.display = 'block';
    }
    else
    {
        btn.textContent = 'More';
        document.getElementById('extra').style.display = 'none';
    }
}