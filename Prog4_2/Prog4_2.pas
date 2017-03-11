var
  Str : string;
  MaxWord, i : longint;
  Gist : array[0..1000] of longint;
begin
  assign(input,'input.txt');reset(input);
  while not eof do
    begin
      Readln(Str);
      while pos(' ', Str) <> 0 do
        begin
          inc(Gist[pos(' ', Str) - 1]);
          if (pos(' ', Str) - 1 > MaxWord) then MaxWord := pos(' ', Str) - 1;
          delete(Str, 1, pos(' ', Str));
        end;
      inc(Gist[length(Str)]);
    end;
    for i := 1 to MaxWord do Writeln('Number of words with length of ', i, ': ', Gist[i]);
    Readln;
end.